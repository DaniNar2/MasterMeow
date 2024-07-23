using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private ShopManager instance;
    public AudioSource audioSource;
    public AudioClip purchaseSound;
    
    public GameObject woolText, basketText, soccerText, kawaiiText, tazzeText, tondiText;
    public Button woolB, basketB, soccerB, kawaiiB, tazzeB, tondiB;
    public GameObject woolCoin, basketCoin, soccerCoin, kawaiiCoin, tazzeCoin, tondiCoin;
    public bool woolSbloccato = false, basketSbloccato = false, soccerSbloccato = false, kawaiiSbloccato = false, tazzeSbloccato = false, tondiSbloccato = false;
    public CoinManager coinManager;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        coinManager.Start();
    }

    public void BuyWool()
    {
        if(coinManager.coins > 20)
        {
        coinManager.coins -= 20;
        coinManager.coinText.text = coinManager.coins.ToString();
        PlayerPrefs.SetInt("coin", coinManager.coins);
        audioSource.PlayOneShot(purchaseSound);
        woolB.interactable = false;
        woolText.SetActive(false);
        woolCoin.SetActive(false);
        woolSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        
    }
    public void BuyBasket()
    {
        if(coinManager.coins > 20)
        {
            coinManager.coins -= 20;
        coinManager.coinText.text = coinManager.coins.ToString();
        PlayerPrefs.SetInt("coin", coinManager.coins);
        audioSource.PlayOneShot(purchaseSound);
        basketB.interactable = false;
        basketText.SetActive(false);
        basketCoin.SetActive(false);
        basketSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        
    }

    public void BuySoccer()
    {
        if(coinManager.coins > 20)
        {
            coinManager.coins -= 20;
        coinManager.coinText.text = coinManager.coins.ToString();
        PlayerPrefs.SetInt("coin", coinManager.coins);
        audioSource.PlayOneShot(purchaseSound);
        soccerB.interactable = false;
        soccerText.SetActive(false);
        soccerCoin.SetActive(false);
        soccerSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        
    }

    public void BuyKawaii()
    {
        if(coinManager.coins > 20)
        {
        coinManager.coins -= 20;
        coinManager.coinText.text = coinManager.coins.ToString();
        
        audioSource.PlayOneShot(purchaseSound);
        kawaiiB.interactable = false;
        kawaiiText.SetActive(false);
        kawaiiCoin.SetActive(false);
        kawaiiSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        PlayerPrefs.SetInt("coin", coinManager.coins);
    }

    public void BuyTazze()
    {
        if(coinManager.coins > 20)
        {
            coinManager.coins -= 20;
            coinManager.coinText.text = coinManager.coins.ToString();
            PlayerPrefs.SetInt("coin", coinManager.coins);
        audioSource.PlayOneShot(purchaseSound);
        tazzeB.interactable = false;
        tazzeText.SetActive(false);
        tazzeCoin.SetActive(false);
        tazzeSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        
    }

    public void BuyTondi()
    {
        if(coinManager.coins > 20)
        {
            coinManager.coins -= 20;
            coinManager.coinText.text = coinManager.coins.ToString();
            PlayerPrefs.SetInt("coin", coinManager.coins);
            audioSource.PlayOneShot(purchaseSound);
            tondiB.interactable = false;
            tondiText.SetActive(false);
            tondiCoin.SetActive(false);
            tondiSbloccato = true;
        }
        else
          Debug.Log("Not enough money!");
        
    }
}
