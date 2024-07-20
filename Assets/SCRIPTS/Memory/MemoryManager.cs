using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    public static MemoryManager instance;

    public Board myBoard;

    bool hasGameFinished, isFirstTurn;
    Card first;

    public GameObject finishPanel;
    public GameObject messageWin;

    public void Replay()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        myBoard = new Board();
        hasGameFinished = false;
        isFirstTurn = true;
        finishPanel.SetActive(false);
        messageWin.SetActive(false);
    }

    public void CardClicked(Card card)
    {
        if (hasGameFinished) return;

        if (isFirstTurn)
        {
            first = card;
            first.UpdateTurn();
        }
        else
        {
            Card second = card;
            second.UpdateTurn();

            if (first.cat == second.cat)
            {
                first.hasTurnFinished = true;
                second.hasTurnFinished = true;
                if (myBoard.UpdateChoice())
                {
                    hasGameFinished = true;
                    Win();
                    return;
                }
                isFirstTurn = !isFirstTurn;
                return;
            }
            else
            {
                
            first.RemoveTurn();
            second.RemoveTurn();
            }
        }
        isFirstTurn = !isFirstTurn;
    }



    private void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(1f);
        finishPanel.SetActive(true);
        messageWin.SetActive(true);
        CoinManager.instance.AddPointsMemory();
    }
}