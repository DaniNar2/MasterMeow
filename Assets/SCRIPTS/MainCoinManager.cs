using UnityEngine;
using UnityEngine.UI;

public class MainCoinManager : MonoBehaviour
{
    public Text coinText;

    void OnEnable()
    {
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (CoinManager.instance != null && coinText != null)
        {
            coinText.text = "" + CoinManager.instance.GetCoins();
        }
    }
}
