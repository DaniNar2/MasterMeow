using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MememoryLoader : MonoBehaviour
{
    [SerializeField] List<Sprite> lstItem = new List<Sprite>();
    private GameObject[] slot; //funziona con serializefield


    // Start is called before the first frame update
    void Awake()
    {
        slot = GameObject.FindGameObjectsWithTag("Slot");

        
    }

    void Start()
    {
        Shuffle();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Shuffle()
    {
        List<Sprite> lstTemp = lstItem;
        lstTemp.AddRange(lstItem);

        for(int i=0; i< slot.Length; i++)
        {
            int rnd = Random.Range(0, lstTemp.Count);
            SpriteRenderer target = slot[i].transform.Find("CatImage").GetComponent<SpriteRenderer>();
            target.sprite = lstTemp[rnd];
            lstTemp.RemoveAt(rnd);
            target.enabled = true;
            
        }
    }
}
