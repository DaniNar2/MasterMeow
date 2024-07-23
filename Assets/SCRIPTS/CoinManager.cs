using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text coinText;
    public int coins = 0;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        coinText.text = coins.ToString();
    }

    public void AddPointsRPSWin()
    {
        Debug.Log("AddPointsRpsWin called");
        coins += 2;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coin", coins);
    }

    public void AddPointsRPSDraw()
    {
        Debug.Log("AddPointsRpsDraw called");
        coins += 1;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

    public void AddPointsMemory()
    {
        Debug.Log("AddPointsMemory called");
        coins += 2;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

    public void AddPointsTTTWin()
    {
        Debug.Log("AddPointsTTT called");
        coins += 2;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

    public void AddPointsTTTDraw()
    {
        Debug.Log("AddPointsTTT called");
        coins += 2;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

    public void AddPointsMasterMeow()
    {
        Debug.Log("AddPointsMasterMeow called");
        coins += 4;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }

}
