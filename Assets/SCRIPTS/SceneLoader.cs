using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadRPS()
    {
        SceneManager.LoadScene("RPS");
    }

    public void LoadMememory()
    {
        SceneManager.LoadScene("Mememory");
    }

    public void LoadTTT()
    {
        SceneManager.LoadScene("TicTacToe");
    }
    
}
