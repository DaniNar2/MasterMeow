using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TTTManager : MonoBehaviour
{
    public Image[] buttonList;
    public Sprite spriteX, spriteO;
    private Image playerImage;
    private Sprite playerSide;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerImage = GetComponent<Image>();
        playerSide = spriteX;
        playerImage.sprite = playerSide;
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

    public Sprite GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        if(buttonList[0].sprite == playerSide && buttonList[1].sprite == playerSide && buttonList[2].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[3].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[5].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[6].sprite == playerSide && buttonList[7].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[0].sprite == playerSide && buttonList[3].sprite == playerSide && buttonList[6].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[1].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[7].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[2].sprite == playerSide && buttonList[5].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[0].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[8].sprite == playerSide)
        {
            GameOver();
        }
        if(buttonList[2].sprite == playerSide && buttonList[4].sprite == playerSide && buttonList[6].sprite == playerSide)
        {
            GameOver();
        }
        ChangeSides();
    }

    public void GameOver()
    {
        for(int i=0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    public void ChangeSides()
    {
        playerSide = (playerSide == spriteX) ? spriteO : spriteX;
        playerImage.sprite = playerSide;
    }
}
