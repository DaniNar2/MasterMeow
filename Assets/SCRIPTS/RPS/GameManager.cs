using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Choices { ROCK, PAPER, SCISSORS, NONE }

public class GameManager : MonoBehaviour
{
    const string result = "Loading result...";
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

    // Riferimento al CoinManager
    private CoinManager coinManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerName = "Player";
        opponentName = "Opponent";
        isOpponentAI = true;
        finishPanel.SetActive(false);
        messageWin.SetActive(false);
        messageLose.SetActive(false);
        messageDraw.SetActive(false);
    }

    void Start()
    {
        // Trova il CoinManager nella scena
        coinManager = CoinManager.instance;
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
        bool win = false;
        bool lose = false;

        if (playerChoice == opponentChoice)
        {
            winningMessageText.text = result;
        }
        else if (playerChoice == Choices.PAPER && opponentChoice == Choices.ROCK)
        {
            winningMessageText.text = result;
            win = true;
        }
        else if (playerChoice == Choices.ROCK && opponentChoice == Choices.SCISSORS)
        {
            winningMessageText.text = result;
            win = true;
        }
        else if (playerChoice == Choices.SCISSORS && opponentChoice == Choices.PAPER)
        {
            winningMessageText.text = result;
            win = true;
        }
        else if (playerChoice == Choices.PAPER && opponentChoice == Choices.SCISSORS)
        {
            winningMessageText.text = result;
            lose = true;
        }
        else if (playerChoice == Choices.ROCK && opponentChoice == Choices.PAPER)
        {
            winningMessageText.text = result;
            lose = true;
        }
        else if (playerChoice == Choices.SCISSORS && opponentChoice == Choices.ROCK)
        {
            winningMessageText.text = result;
            lose = true;
        }
        SetImage();
        SetAnimation();
        if (win == true)
        {
            StartCoroutine(DelayedResult(Win));
        }
        else if (lose == true)
        {
            StartCoroutine(DelayedResult(Lose));
        }
        else
        {
            StartCoroutine(DelayedResult(Draw));
        }
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
        finishPanel.SetActive(true);
        messageWin.SetActive(true);
        coinManager.AddCoins(2); // Aggiungi 2 monete in caso di vittoria
    }

    void Lose()
    {
        finishPanel.SetActive(true);
        messageLose.SetActive(true);
        coinManager.AddCoins(0); // Aggiungi 0 monete in caso di sconfitta
    }

    void Draw()
    {
        finishPanel.SetActive(true);
        messageDraw.SetActive(true);
        coinManager.AddCoins(1); // Aggiungi 1 moneta in caso di pareggio
    }
}
