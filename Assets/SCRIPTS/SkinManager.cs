using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] MasterMeow masterMeow;
    public Image woolIm, basketIm, soccerIm, kawaiiIm, tazzeIm, tondiIm;
    public Sprite bloccato, wool, basket, soccer, kawaii, tazze, tondi;
    public bool woolSbloccato = false, basketSbloccato = false, soccerSbloccato = false, kawaiiSbloccato = false, tazzeSbloccato = false, tondiSbloccato = false;

    public int coins;
    public Text CoinTXT;

    void Start(){
        CoinTXT.text = coins.ToString();
        
    }

    public void Awake()
    {
        woolIm.sprite = bloccato;
        basketIm.sprite = bloccato;
        soccerIm.sprite = bloccato;
        kawaiiIm.sprite = bloccato;
        tazzeIm.sprite = bloccato;
        tondiIm.sprite = bloccato;
    }

    public void ChangeToDefault()
    {
        masterMeow.SetSkinSet("Default");
    }

    public void ChangeToWool()
    {
        if(woolSbloccato)
        {
            woolIm.sprite = wool;
            masterMeow.SetSkinSet("Wool");
        }
        
    }

    public void ChangeToBasket()
    {
        if(basketSbloccato)
        {
            basketIm.sprite = basket;
            masterMeow.SetSkinSet("Basket");
        }
        
    }
    public void ChangeToSoccer()
    {
        if(soccerSbloccato)
        {
            soccerIm.sprite = soccer;
            masterMeow.SetSkinSet("Soccer");
        }
    }
    public void ChangeToKawaii()
    {
        if(kawaiiSbloccato)
        {
            kawaiiIm.sprite = kawaii;
            masterMeow.SetSkinSet("Kawaii");
        }
    }
    public void ChangeToTazza()
    {
        if(tazzeSbloccato)
        {
            tazzeIm.sprite = tazze;
            masterMeow.SetSkinSet("Tazza");
        }
    }
    public void ChangeToTondi()
    {
        if(tondiSbloccato)
        {
            tondiIm.sprite = tondi;
            masterMeow.SetSkinSet("Tondi");
        }
    }
}
