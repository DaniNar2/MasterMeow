using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] MasterMeow masterMeow;

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
        masterMeow.SetSkinSet("Basket");
    }

    public void ChangeToSoccer()
    {
        masterMeow.SetSkinSet("Soccer");
    }
}
