using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

[System.Serializable]
public class Player
{
    public Image panel, side;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
}

public class TTTManager : MonoBehaviour
{
    public Image[] buttonList;
    public Sprite spriteX, spriteO;
    private Image playerImage;
    private Sprite playerSide;
    public GameObject gameOverPanel, winMessage, loseMessage, drawMessage;
    private int moveCount;
    public AudioSource audioSource;
    public AudioClip clickSound, winSound, drawSound;
    public Player playerX, playerO;
    public PlayerColor active, inactive;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        winMessage.SetActive(false);
        loseMessage.SetActive(false);
        drawMessage.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerImage = GetComponent<Image>();
        playerImage.sprite = playerSide;
        moveCount = 0;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetGameControllerReferenceOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(Sprite startingSide)
    {
        playerSide = startingSide;
        if(playerSide == spriteX)
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
        StartGame();
    }

    public void StartGame()
    {
        for(int i=0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
        }
    }

    public Sprite GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if(buttonList[0].sprite == playerSide && buttonList[1].sprite == playerSide && buttonList[2].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[3].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[5].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[6].sprite == playerSide && buttonList[7].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[0].sprite == playerSide && buttonList[3].sprite == playerSide && buttonList[6].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[1].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[7].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[2].sprite == playerSide && buttonList[5].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[0].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(buttonList[2].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[6].sprite == playerSide)
        {
            GameOver();
            winMessage.SetActive(true);
            audioSource.PlayOneShot(winSound);
        }
        else if(moveCount >= 9)
        {
            gameOverPanel.SetActive(true);
            drawMessage.SetActive(true);
            audioSource.PlayOneShot(drawSound);
            SetPlayerColorsInactive();
        }
        else
        {
            ChangeSides();
        }
        
    }

    public void GameOver()
    {
        for(int i=0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        gameOverPanel.SetActive(true);
    }

    public void ChangeSides()
    {
        playerSide = (playerSide == spriteX) ? spriteO : spriteX;
        playerImage.sprite = playerSide;
        if(playerSide == spriteX)
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    public void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = active.panelColor;
        oldPlayer.panel.color = inactive.panelColor;
    }

    public void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactive.panelColor;
        playerO.panel.color = inactive.panelColor;
    }
}
