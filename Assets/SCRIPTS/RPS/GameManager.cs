using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum Choices { ROCK, PAPER, SCISSORS, NONE }

public class GameManager : MonoBehaviour
{
    const string win = " Wins!";
    const string draw = "Draw!";
    public static GameManager instance;
    Choices playerChoice = Choices.NONE, opponentChoice = Choices.NONE;
    bool isPlayerSelected, isOpponentSelected, isGameFinished, isOpponentAI;
   string playerName, opponentName;
   [SerializeField] Text winningMessageText;
    [SerializeField] Image playerImage, opponentImage;
    [SerializeField] Sprite playerSprite, opponentSprite;
    [SerializeField] Animator playerChoiceAnim, opponentChoiceAnim, playerSelectAnim, opponentSelectAnim;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        playerName = "Player";
        opponentName = "Opponent";
        isOpponentAI = true;
    }

    public void Select(Choices myChoice, bool isPlayer)
    {
        if(isGameFinished)
        {
            return;
        }
        if(isPlayer)
        {
            playerChoice = myChoice;
            isPlayerSelected = true;
            if(isOpponentAI)
            {
                Select((Choices)Random.Range(0, 3), false);
            }
        }
        else
        {
            opponentChoice = myChoice;
            isOpponentSelected = true;
        }
        if(isPlayerSelected && isOpponentSelected)
        {
            isGameFinished = true;
            DetermineWinner();
        }
        
    }

    public void DetermineWinner()
    {
        if(playerChoice == opponentChoice)
        {
            winningMessageText.text = draw;
        }
        else if(playerChoice == Choices.PAPER && opponentChoice == Choices.ROCK)
        {
            winningMessageText.text = playerName + win;
        }
        else if(playerChoice == Choices.ROCK && opponentChoice == Choices.SCISSORS)
        {
            winningMessageText.text = playerName + win;
        }
        else if(playerChoice == Choices.SCISSORS && opponentChoice == Choices.PAPER)
        {
            winningMessageText.text = playerName + win;
        }
        else if(playerChoice == Choices.PAPER && opponentChoice == Choices.SCISSORS)
        {
            winningMessageText.text = opponentName + win;
        }
        else if(playerChoice == Choices.ROCK && opponentChoice == Choices.PAPER)
        {
            winningMessageText.text = opponentName + win;
        }
        else if(playerChoice == Choices.SCISSORS && opponentChoice == Choices.ROCK)
        {
            winningMessageText.text = opponentName + win;
        }
        SetImage();
        SetAnimation();
    }

    public void SetImage()
    {
        playerImage.sprite = playerSprite;
        opponentImage.sprite = opponentSprite;
    }

    public void SetAnimation()
    {
        playerChoiceAnim.Play("anim_PlayerChoiceMove");
        opponentChoiceAnim.Play("anim_OpponentChoiceMove");
        playerSelectAnim.Play("anim_PlayerSelectedMove");
        opponentSelectAnim.Play("anim_OpponentSelectedMove");
    }
}
