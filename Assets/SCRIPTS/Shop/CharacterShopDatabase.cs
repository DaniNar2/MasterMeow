using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterShopDatabase",menuName = "Shopping/Characters shop database")]
public class CharacterS : ScriptableObject
{
    public Character[] characters;

    public int characterCount{
        get { return characters.Length; }
    }

    public Character GetCharacter (int index)
	{
		return characters [index];
	}

	public void PurchaseCharacter (int index)
	{
		characters [index].isPurchased = true;
	}
}
