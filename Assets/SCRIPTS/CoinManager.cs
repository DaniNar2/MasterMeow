using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text coinText;
    private int coins = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Assicurati che il CoinManager non venga distrutto quando cambi scena
        }
        else
        {
            Destroy(gameObject); // Assicurati che non ci siano duplicati del CoinManager
        }
        // Carica le monete salvate
        LoadCoins();
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
        UpdateCoinText(); // Aggiorna il testo delle monete nella schermata attuale, se presente
    }

    public int GetCoins()
    {
        return coins;
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "" + coins;
        }
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
    }
}
