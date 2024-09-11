using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class expDrop : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int exp = 5;
    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Level level = PlayerCtr.myLevel;

        level.AddExp(this.exp);
        Destroy(gameObject);
    }
    public void MoveToTarget()
    {

        transform.DOMove(GameObject.FindGameObjectWithTag("Player").transform.position, .5f);
    }
}
