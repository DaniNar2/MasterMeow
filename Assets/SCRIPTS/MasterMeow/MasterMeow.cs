using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class MasterMeow : MonoBehaviour
{
    public Sprite Cat11, Cat12, Cat13, Cat14, Cat15, Cat16, GoodCat, WrongCat;
    public Sprite Cat21, Cat22, Cat23, Cat24, Cat25, Cat26;
    public Sprite Cat31, Cat32, Cat33, Cat34, Cat35, Cat36;
    public Sprite Cat41, Cat42, Cat43, Cat44, Cat45, Cat46;
    public Sprite Cat51, Cat52, Cat53, Cat54, Cat55, Cat56;
    public Sprite Cat61, Cat62, Cat63, Cat64, Cat65, Cat66;
    public Sprite Cat71, Cat72, Cat73, Cat74, Cat75, Cat76;
    public GameObject set11, set12, set13, set14, set15, set16;
    public GameObject set21, set22, set23, set24, set25, set26;
    public GameObject set31, set32, set33, set34, set35, set36;
    public GameObject set41, set42, set43, set44, set45, set46;
    public GameObject set51, set52, set53, set54, set55, set56;
    public GameObject set61, set62, set63, set64, set65, set66;
    public GameObject set71, set72, set73, set74, set75, set76;
    public string[] secretCode = new string[4];
    public string[] secretCodeTemp = new string[4];
    private Dictionary<string, Sprite> dicoSprite = new Dictionary<string, Sprite>();
    private string[] codePlayer = new string[4];
    public GameObject hiddenSlot;
    public GameObject finishPanel;
    public GameObject messageWin;
    public GameObject messageLose;
    public string skinSet;
    public bool isSkinSetSelected = false;

    void Awake()
    {
        set11.SetActive(false);
        set12.SetActive(false);
        set13.SetActive(false);
        set14.SetActive(false);
        set15.SetActive(false);
        set16.SetActive(false);
        set21.SetActive(false);
        set22.SetActive(false);
        set23.SetActive(false);
        set24.SetActive(false);
        set25.SetActive(false);
        set26.SetActive(false);
        set31.SetActive(false);
        set32.SetActive(false);
        set33.SetActive(false);
        set34.SetActive(false);
        set35.SetActive(false);
        set36.SetActive(false);
    }

    public void SetSkinSet(string newSkinSet)
    {
        skinSet = newSkinSet;
        isSkinSetSelected = true;
        UpdateSkinSet();
        GetNewSecretCode();
    }

    private void UpdateSkinSet()
    {
        dicoSprite.Clear();

        if (skinSet == "Default")
        {
            dicoSprite.Add("BlackCat", Cat11);
            dicoSprite.Add("CowCat", Cat12);
            dicoSprite.Add("GreyCat", Cat13);
            dicoSprite.Add("OrangeCat", Cat14);
            dicoSprite.Add("StripesCat", Cat15);
            dicoSprite.Add("WhiteCat", Cat16);
            set11.SetActive(true);
            set12.SetActive(true);
            set13.SetActive(true);
            set14.SetActive(true);
            set15.SetActive(true);
            set16.SetActive(true);
        }
        else if (skinSet == "Wool")
        {
            dicoSprite.Add("BlueWoolCat", Cat21);
            dicoSprite.Add("BWoolCat", Cat22);
            dicoSprite.Add("GreenWoolCat", Cat23);
            dicoSprite.Add("LigGreenWoolCat", Cat24);
            dicoSprite.Add("PinkWoolCat", Cat25);
            dicoSprite.Add("WhiteWoolCat", Cat26);
            set21.SetActive(true);
            set22.SetActive(true);
            set23.SetActive(true);
            set24.SetActive(true);
            set25.SetActive(true);
            set26.SetActive(true);
        }
        else if (skinSet == "Basket")
        {
            dicoSprite.Add("BlackBasketCat", Cat31);
            dicoSprite.Add("BrownBasketCat", Cat32);
            dicoSprite.Add("GreyBasketCat", Cat33);
            dicoSprite.Add("OranBasketCat", Cat34);
            dicoSprite.Add("StripesBasketCat", Cat35);
            dicoSprite.Add("WhiteBasketCat", Cat36);
            set31.SetActive(true);
            set32.SetActive(true);
            set33.SetActive(true);
            set34.SetActive(true);
            set35.SetActive(true);
            set36.SetActive(true);
        }
        else if (skinSet == "Soccer")
        {
            dicoSprite.Add("BlackBallCat", Cat41);
            dicoSprite.Add("BrownBallCat", Cat42);
            dicoSprite.Add("OrangeBallCat", Cat43);
            dicoSprite.Add("StripesBallCat", Cat44);
            dicoSprite.Add("WhiteBallCat", Cat45);
            dicoSprite.Add("YellowBallCat", Cat46);
            set41.SetActive(true);
            set42.SetActive(true);
            set43.SetActive(true);
            set44.SetActive(true);
            set45.SetActive(true);
            set46.SetActive(true);
        }
        else if (skinSet == "Kawaii")
        {
            dicoSprite.Add("BlueKawaii", Cat51);
            dicoSprite.Add("GreenKawaii", Cat52);
            dicoSprite.Add("GreyKawaii", Cat53);
            dicoSprite.Add("LBKawaii", Cat54);
            dicoSprite.Add("LGKawaii", Cat55);
            dicoSprite.Add("PinkKAwaii", Cat56);
            set51.SetActive(true);
            set52.SetActive(true);
            set53.SetActive(true);
            set54.SetActive(true);
            set55.SetActive(true);
            set56.SetActive(true);
        }
        else if (skinSet == "Tazza")
        {
            dicoSprite.Add("BlueLTazza", Cat61);
            dicoSprite.Add("BlueTazza", Cat62);
            dicoSprite.Add("GreenTazza", Cat63);
            dicoSprite.Add("PinkTazza", Cat64);
            dicoSprite.Add("RedTazza", Cat65);
            dicoSprite.Add("YellowTazza", Cat66);
            set61.SetActive(true);
            set62.SetActive(true);
            set63.SetActive(true);
            set64.SetActive(true);
            set65.SetActive(true);
            set66.SetActive(true);
        }
        else if (skinSet == "Tondi")
        {
            dicoSprite.Add("BlueTondo", Cat71);
            dicoSprite.Add("GreenTondo", Cat72);
            dicoSprite.Add("GreyTondo", Cat73);
            dicoSprite.Add("LGreenTondo", Cat74);
            dicoSprite.Add("PinkTondo", Cat75);
            dicoSprite.Add("YellowTondo", Cat76);
            set71.SetActive(true);
            set72.SetActive(true);
            set73.SetActive(true);
            set74.SetActive(true);
            set75.SetActive(true);
            set76.SetActive(true);
        }
    }

    public Array GetNewSecretCode()
    {
        if(isSkinSetSelected)
        {
            for (int i = 0; i < 4; i++)
        {
            int rnd = UnityEngine.Random.Range(0, dicoSprite.Count);
            secretCode.SetValue(dicoSprite.ElementAt(rnd).Key, i);
        }

        transform.Find("C1").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(0).ToString()];
        transform.Find("C2").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(1).ToString()];
        transform.Find("C3").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(2).ToString()];
        transform.Find("C4").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(3).ToString()];
        }
        
        

        return secretCode;
    }

    public int GetGoodPosition(string[] code)
    {
        Array.Copy(secretCode, secretCodeTemp, secretCode.Length);
        int good = 0;
        for (int i = 0; i < secretCodeTemp.Length; i++)
        {
            if (code[i] == secretCodeTemp[i])
            {
                good++;
                code[i] = "good";
                secretCodeTemp[i] = "good";
            }
        }
        Array.Copy(code, codePlayer, code.Length);
        return good;
    }

    public int GetWrongPosition()
    {
        int wrong = 0;
        for (int i = 0; i < codePlayer.Length; i++)
        {
            for (int j = 0; j < secretCodeTemp.Length; j++)
            {
                if (codePlayer[i] == secretCodeTemp[j] && codePlayer[i] != "good" && secretCodeTemp[j] != "good")
                {
                    secretCodeTemp[j] = "wrong";
                    wrong++;
                    break;
                }
            }
        }
        return wrong;
    }
}