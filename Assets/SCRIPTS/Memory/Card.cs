using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector]
    public bool hasClicked, hasTurnFinished;

    [SerializeField]
    int index;

    [HideInInspector]
    public int cat;

    [SerializeField]
    Sprite unrevealed;

    [SerializeField]
    List<Sprite> cats;

    Image renderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hasClicked = false;
        hasTurnFinished = false;
        cat = MemoryManager.instance.myBoard.GetIndex(index);
        renderer = GetComponent<Image>();
        animator = GetComponent<Animator>();
        renderer.sprite = unrevealed;
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
        renderer.sprite = cats[cat];
    }

    public void RemoveTurn()
    {
        StartCoroutine(RemoveTurnCoroutine());
    }

    private IEnumerator RemoveTurnCoroutine()
    {
        yield return new WaitForSeconds(1f); 
        hasClicked = false;
       if (!hasTurnFinished)
        {
            animator.Play("Unreveal", -1, 0f);
        }
    }

    public void RemoveImage()
    {
        renderer.sprite = unrevealed;
    }
}