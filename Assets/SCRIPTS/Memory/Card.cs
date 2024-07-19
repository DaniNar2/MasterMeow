using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    SpriteRenderer renderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hasClicked = false;
        hasTurnFinished = false;
        cat = MemoryManager.instance.myBoard.GetIndex(index);
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        renderer.sprite = unrevealed;
    }

    public void UpdateTurn()
    {
        hasClicked = true;
        animator.Play("Reveal", -1, 0f);
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
        animator.Play("Unreveal", -1, 0f);
    }

    public void RemoveImage()
    {
        renderer.sprite = unrevealed;
    }
}