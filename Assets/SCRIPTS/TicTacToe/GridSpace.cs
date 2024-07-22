using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button gridSpace;
    public Image gridSpaceImage;
    public Sprite playerSide;
    public GameObject image;

    public void SetSpace()
    {
        gridSpaceImage.sprite = playerSide;
        image.SetActive(true);
        gridSpace.interactable = false;
    }
}
