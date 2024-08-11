using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawOder : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] Transform player;
    private SpriteRenderer thisObjectSprite;
    private int currentOderInLayer;
    private int playerCurrentOderInLayer;
    public bool playerInRange = false;
    public List<Transform> objInRange = new List<Transform>();


    private void Awake()
    {
        thisObjectSprite = transform.parent.Find("Model").GetComponent<SpriteRenderer>();
        currentOderInLayer = thisObjectSprite.sortingOrder;
        // player = GameObject.FindWithTag("Player").transform;
        // this.playerCurrentOderInLayer = player.Find("Model").GetComponent<SpriteRenderer>().sortingOrder;
    }


    private void ChangeOderToPlayerOder(Transform ojbInRange)
    {
        if (transform.parent.position.y > ojbInRange.position.y)
        {
            ChangeOderLayer(thisObjectSprite.sortingOrder + 1, ojbInRange);
            transform.parent.GetComponent<Transparent>().End();

            return;
        }

        ChangeOderLayer(thisObjectSprite.sortingOrder - 1, ojbInRange);
        if (ojbInRange.tag != "Player") return;
        transform.parent.GetComponent<Transparent>().BeginTraparent();



    }
    void ChangeOderLayer(int newOderInLayer, Transform ojbInRange)
    {

        currentOderInLayer = newOderInLayer;
        if (!ojbInRange.Find("Model")) return;
        ojbInRange.Find("Model").GetComponent<SpriteRenderer>().sortingOrder = currentOderInLayer;

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // if (!other.CompareTag("Player")) return;
        ChangeOderToPlayerOder(other.transform);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        transform.parent.GetComponent<Transparent>().End();
    }
    // bool check
}
