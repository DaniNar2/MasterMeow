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
    public AudioClip cardFlipSound;
    public AudioClip matchSound;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    public void CardClicked(Card card)
    {
        if (hasGameFinished) return;

        if (isFirstTurn)
        {
            first = card;
            first.UpdateTurn();
            audioSource.PlayOneShot(cardFlipSound);

        }
        else
        {
            Card second = card;
            second.UpdateTurn();
            audioSource.PlayOneShot(cardFlipSound);


            if (first.cat == second.cat)
            {
                first.hasTurnFinished = true;
                second.hasTurnFinished = true;
                audioSource.PlayOneShot(matchSound);

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