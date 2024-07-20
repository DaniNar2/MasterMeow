using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector] public bool hasClicked, hasTurnFinished;

    public int index;
   
    [HideInInspector] public int cat;
    
    [SerializeField] Sprite unrevealed;
    
    [SerializeField] List<Sprite> cats;

    Image image;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hasClicked = false;
        hasTurnFinished = false;
        cat = MemoryManager.instance.myBoard.GetIndex(index);
        image = GetComponent<Image>();
        animator = GetComponent<Animator>();
        image.sprite = unrevealed;
    }

    public void UpdateTurn()
    {
        if (hasTurnFinished || hasClicked) return;

        hasClicked = true;
        animator.Play("Reveal", -1, 0f);
        MemoryManager.instance.CardClicked(this);
    }

    public void UpdateImage()
    {
        image.sprite = cats[cat];
    }

    public void RemoveTurn()
    {
        StartCoroutine(RemoveTurnCoroutine());
    }

    private IEnumerator RemoveTurnCoroutine()
    {
        yield return new WaitForSeconds(1f); 
        hasClicked = false;
        animator.Play("Unreveal", -1, 0f);
    
    }

    public void RemoveImage()
    {
        image.sprite = unrevealed;
    }
}