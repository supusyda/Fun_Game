using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArgo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EnemyBase enemy;
    Collider2D collider2D;
    private void Awake()
    {
        enemy = GetComponentInParent<EnemyBase>();
        collider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crew"))
        {
            enemy.setIsArgo(true);
            enemy.target = other.transform;
            // collider2D.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Crew"))
        {

            enemy.setIsArgo(false);
            // enemy.target = null;

            // collider2D.enabled = true;
        }
    }
}
