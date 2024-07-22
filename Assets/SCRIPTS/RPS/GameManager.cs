using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Choices { ROCK, PAPER, SCISSORS, NONE }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Choices playerChoice = Choices.NONE, opponentChoice = Choices.NONE;
    bool isPlayerSelected, isOpponentSelected, isGameFinished, isOpponentAI;
    string playerName, opponentName;
    [SerializeField] Text winningMessageText;
    [SerializeField] Image playerImage, opponentImage;
    [SerializeField] Sprite rockSprite, paperSprite, scissorsSprite;
    [SerializeField] Animator playerChoiceAnim, opponentChoiceAnim, playerSelectAnim, opponentSelectAnim;

    public GameObject finishPanel;
    public GameObject messageWin, messageLose, messageDraw;
    private AudioSource audioSource;
    private AudioClip winSound, loseSound, drawSound;

    void Awake()
    {
    
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        playerName = "Player";
        opponentName = "Opponent";
        isOpponentAI = true;
        finishPanel.SetActive(false);
        messageWin.SetActive(false);
        messageLose.SetActive(false);
        messageDraw.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void Select(Choices myChoice, bool isPlayer)
    {
        if (isGameFinished)
        {
            return;
        }
        if (isPlayer)
        {
            playerChoice = myChoice;
            isPlayerSelected = true;
            if (isOpponentAI)
            {
                Select((Choices)Random.Range(0, 3), false);
            }
        }
        else
        {
            opponentChoice = myChoice;
            isOpponentSelected = true;
        }
        if (isPlayerSelected && isOpponentSelected)
        {
            isGameFinished = true;
            DetermineWinner();
        }
    }

    public void DetermineWinner()
    {
        if (playerChoice == opponentChoice)
        {
            StartCoroutine(DelayedResult(Draw));
        }
        else if ((playerChoice == Choices.PAPER && opponentChoice == Choices.ROCK) ||
                 (playerChoice == Choices.ROCK && opponentChoice == Choices.SCISSORS) ||
                 (playerChoice == Choices.SCISSORS && opponentChoice == Choices.PAPER))
        {
            StartCoroutine(DelayedResult(Win));
        }
        else
        {
            StartCoroutine(DelayedResult(Lose));
        }
        SetImage();
        SetAnimation();
    }

    IEnumerator DelayedResult(System.Action resultAction)
    {
        yield return new WaitForSeconds(2);
        resultAction.Invoke();
    }

    public void SetImage()
    {
        SetImage(playerImage, playerChoice);
        SetImage(opponentImage, opponentChoice);
    }

    public void SetImage(Image target, Choices mychoice)
    {
        switch (mychoice)
        {
            case Choices.ROCK:
                target.sprite = rockSprite;
                break;
            case Choices.PAPER:
                target.sprite = paperSprite;
                break;
            case Choices.SCISSORS:
                target.sprite = scissorsSprite;
                break;
        }
    }

    public void SetAnimation()
    {
        playerChoiceAnim.Play("anim_PlayerChoiceMove");
        opponentChoiceAnim.Play("anim_OpponentChoiceMove");
        playerSelectAnim.Play("anim_PlayerSelectedMove");
        opponentSelectAnim.Play("anim_OpponentSelectedMove");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Win()
    {
        if (!finishPanel.activeInHierarchy)
        {
            audioSource.PlayOneShot(winSound);
            finishPanel.SetActive(true);
            messageWin.SetActive(true);
            CoinManager.instance.AddPointsRPSWin();
        }
    }

    void Lose()
    {
        if (!finishPanel.activeInHierarchy)
        {
            audioSource.PlayOneShot(loseSound);
            finishPanel.SetActive(true);
            messageLose.SetActive(true);
        }
    }

    void Draw()
    {
        if (!finishPanel.activeInHierarchy)
        {
            audioSource.PlayOneShot(drawSound);
            finishPanel.SetActive(true);
            messageDraw.SetActive(true);
            CoinManager.instance.AddPointsRPSDraw();
        }
    }
}
