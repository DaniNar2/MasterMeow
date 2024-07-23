using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [SerializeField] MasterMeow masterMeow;
    public Image woolIm, basketIm, soccerIm, kawaiiIm, tazzeIm, tondiIm;
    public Sprite bloccato, wool, basket, soccer, kawaii, tazze, tondi;
    public ShopManager shop;
    private bool cb = false, cw = false, ctz = false, ct = false, cc = false, ck = false, cd = false;
    private SkinManager instance;
    
    



    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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
        masterMeow.SetSkinSet("Wool");
    }

    

    public void ChangeToBasket()
    {
        if(shop.basketSbloccato)
            masterMeow.SetSkinSet("Basket");
    }
    public void ChangeToSoccer()
    {
        if(shop.soccerSbloccato)
            masterMeow.SetSkinSet("Soccer");
    }
    public void ChangeToKawaii()
    {
        masterMeow.SetSkinSet("Kawaii");
    }
    public void ChangeToTazza()
    {
        if(shop.tazzeSbloccato)
            masterMeow.SetSkinSet("Tazza");
    }
    public void ChangeToTondi()
    {
        if(shop.tondiSbloccato)
            masterMeow.SetSkinSet("Tondi");
    }
}
