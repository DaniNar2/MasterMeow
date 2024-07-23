using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    private TTTManager tTTManager;
    public Button gridSpace;
    public Image gridSpaceImage;
    public GameObject image;

    public void SetSpace()
    {
        tTTManager.audioSource.PlayOneShot(tTTManager.clickSound);
        gridSpaceImage.sprite = tTTManager.GetPlayerSide();
        image.SetActive(true);
        gridSpace.interactable = false;
        tTTManager.EndTurn();
        
    }

    public void SetGameControllerReference(TTTManager manager)
    {
        tTTManager = manager;
    }
}
