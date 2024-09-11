using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewTriggerArgo : MonoBehaviour
{
    // Start is called before the first frame update
    AllyBase ally;
    Collider2D collider2D;
    [SerializeField] Transform cc;
    private void Awake()
    {
        ally = GetComponentInParent<AllyBase>();
        collider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ally.setIsArgo(true);
            ally.target = other.transform;
            cc = other.transform;
            // collider2D.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ally.setIsArgo(false);
            ally.target = null;

            // collider2D.enabled = true;
        }
    }
}
