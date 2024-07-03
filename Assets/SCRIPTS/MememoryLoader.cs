using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MemoryLoader : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>(); 
    [SerializeField] AudioClip sfxFound, sfxReturn, flipSound;
    private GameObject[] pads;
    private AudioSource audioSource;

    void Awake()
    {
        pads = GameObject.FindGameObjectsWithTag("Slot");
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        Shuffle();
    }

    void Shuffle()
    {
        List<Sprite> duplicatedSprites = new List<Sprite>(spriteList);
        duplicatedSprites.AddRange(spriteList);

        for (int i = 0; i < duplicatedSprites.Count; i++)
        {
            Sprite temp = duplicatedSprites[i];
            int randomIndex = Random.Range(i, duplicatedSprites.Count);
            duplicatedSprites[i] = duplicatedSprites[randomIndex];
            duplicatedSprites[randomIndex] = temp;
        }

        for (int i = 0; i < pads.Length; i++)
        {
            Image catImage = pads[i].transform.Find("CatImage").GetComponent<Image>();
            if (catImage != null)
            {
                // Assegna lo sprite del retro
                catImage.sprite = duplicatedSprites[i];

                // Aggiungi l'event trigger per rilevare il click e collegarlo direttamente qui
                EventTrigger trigger = pads[i].AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((eventData) => { OnCardClicked(pads[i]); });
                trigger.triggers.Add(entry);
            }
        }
    }

    void OnCardClicked(GameObject pad)
    {
        Image catImage = pad.transform.Find("CatImage").GetComponent<Image>();
        if (catImage != null)
        {
            // Mostra l'immagine di CatImage
            catImage.gameObject.SetActive(true);

            // Nascondi il retro
            GameObject backImage = catImage.transform.parent.gameObject;
            if (backImage != null)
            {
                backImage.SetActive(false);
            }

            // Riproduci il suono del flip
            audioSource.PlayOneShot(flipSound);
        }
    }
}
