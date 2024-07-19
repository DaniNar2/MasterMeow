using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            if (hasGameFinished) return;
            
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            
            if (!hit.collider) return;
            

            if(hit.collider.CompareTag("Card"))
            {
                if (hit.collider.gameObject.GetComponent<Card>().hasTurnFinished) return;

                if(isFirstTurn)
                {
                    first = hit.collider.gameObject.GetComponent<Card>();
                    first.UpdateTurn();
                }
                else
                {
                    Card second = hit.collider.gameObject.GetComponent<Card>();
                    if(second.hasClicked)
                    {
                        first.RemoveTurn();
                        second.RemoveTurn();
                        isFirstTurn = !isFirstTurn;
                        return;
                    }
                    second.UpdateTurn();


                    if(first.cat == second.cat)
                    {
                        first.hasTurnFinished = true;
                        second.hasTurnFinished = true;
                        if(myBoard.UpdateChoice())
                        {
                            hasGameFinished = true;
                            Win();
                            return;
                        }
                        isFirstTurn = !isFirstTurn;
                        return;
                    }

                    first.RemoveTurn();
                    second.RemoveTurn();
                }
                isFirstTurn = !isFirstTurn;
            }
        }
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