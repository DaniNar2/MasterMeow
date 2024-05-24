using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class MasterMeow : MonoBehaviour
{
    public Sprite BlackCat, CowCat, GreyCat, OrangeCat, StripesCat, WhiteCat, GoodCat, WrongCat;
    public string[] secretCode = new string[4];
    public string[] secretCodeTemp = new string[4];
    private Dictionary<string, Sprite> dicoSprite = new Dictionary<string, Sprite>();
    private string[] codePlayer = new string[4];
    public GameObject hiddenSlot;
    void Awake()
    {
        dicoSprite.Add("BlackCat", BlackCat);
        dicoSprite.Add("CowCat", CowCat);
        dicoSprite.Add("GreyCat", GreyCat);
        dicoSprite.Add("OrangeCat", OrangeCat);
        dicoSprite.Add("StripesCat", StripesCat);
        dicoSprite.Add("WhiteCat", WhiteCat);
    }
    public Array GetNewSecretCode()
    {
        for (int i = 0; i<4; i++)
        {
            int rnd = UnityEngine.Random.Range(0, dicoSprite.Count);
            secretCode.SetValue(dicoSprite.ElementAt(rnd).Key, i);
        }

        transform.Find("C1").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(0).ToString()];
        transform.Find("C2").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(1).ToString()];
        transform.Find("C3").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(2).ToString()];
        transform.Find("C4").GetComponent<Image>().sprite = dicoSprite[secretCode.GetValue(3).ToString()];

        return secretCode;
    }


    public int GetGoodPosition(string[] code)
    {   
        Array.Copy(secretCode, secretCodeTemp, secretCode.Length);
        int good = 0;
        for(int i = 0; i < secretCodeTemp.Length; i++)
        {
            if(code[i] == secretCodeTemp[i])
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
        for(int i = 0; i < codePlayer.Length; i++)
        {
            for(int j = 0; j < secretCodeTemp.Length; j++)
            {
                if(codePlayer[i] == secretCodeTemp[j] && codePlayer[i]!="good" && secretCodeTemp[j]!="good")
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
