using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] MasterMeow masterMeow;
    [SerializeField] GameObject[] gameSlot = new GameObject[10];
    [SerializeField] GameObject[] gameVerify = new GameObject[4];  
    private int currentSlot = 0, currentCol = 1;
    private Sprite emptySprite;
    [SerializeField] string[] code = new string[4];

    void Start()
    {
        masterMeow.finishPanel.SetActive(false);
        masterMeow.messageWin.SetActive(false);
        masterMeow.messageLose.SetActive(false);
        masterMeow.GetNewSecretCode();
        emptySprite = gameSlot[currentSlot].transform.Find("C1").GetComponent<Image>().sprite;
    }

    public void ColorSelect(Sprite sp)
    {
        if(!masterMeow.hiddenSlot.activeInHierarchy) return;

        gameSlot[currentSlot].transform.Find("C" + currentCol).GetComponent<Image>().sprite = sp;
        code.SetValue(sp.name, currentCol -1);
        currentCol++;
        if(currentCol == 5) currentCol = 1;
    }

    public void Cancel()
    {
        for(int i = 1; i < 5; i++)
        {
            gameSlot[currentSlot].transform.Find("C" + i).GetComponent<Image>().sprite = emptySprite;
        }
        currentCol = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Check()
    {
       if(!masterMeow.hiddenSlot.activeInHierarchy) return;

       int x = 0;
       foreach(Transform child in gameSlot[currentSlot].transform)
       {
            if(child.tag == "Verify")
            {
                gameVerify[x] = child.gameObject;
                x++;
            }
       }

       for(int i = 1; i < 5; i++)
       {
        if(gameSlot[currentSlot].transform.Find("C" + i).GetComponent<Image>().sprite == emptySprite) return;
       }

       int nbGoodPosition = masterMeow.GetGoodPosition(code);
       for(int i = 0; i < nbGoodPosition; i++)
       {
        gameVerify[i].GetComponent<Image>().sprite = masterMeow.GoodCat;
       }

       int nbWrongPosition = masterMeow.GetWrongPosition();
       for(int i = nbGoodPosition; i < nbWrongPosition + nbGoodPosition; i++)
       {
        gameVerify[i].GetComponent<Image>().sprite = masterMeow.WrongCat;
       }

       if(nbGoodPosition == 4)
       {
        Debug.Log("WINNER!");
        Win();
        return;
       }

       if(currentSlot == 9)
       {
        Debug.Log("LOSER!");
        Lose();
        return;
       }

       currentSlot++;

       Color original = gameSlot[currentSlot].GetComponent<Image>().color;
       Color selected = original;
       selected.a = 0.25f;

       gameSlot[currentSlot].GetComponent<Image>().color = selected;
       gameSlot[currentSlot-1].GetComponent<Image>().color = original;
    }

    void Win()
    {
        masterMeow.hiddenSlot.SetActive(false);
        masterMeow.finishPanel.SetActive(true);
        masterMeow.messageWin.SetActive(true);
        CoinManager.instance.AddPointsMasterMeow();
    }

    void Lose()
    {
        masterMeow.hiddenSlot.SetActive(false);
        masterMeow.finishPanel.SetActive(true);
        masterMeow.messageLose.SetActive(true);
    }
}
