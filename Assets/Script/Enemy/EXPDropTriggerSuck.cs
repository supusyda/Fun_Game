using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EXPDropTriggerSuck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float expDropDistance = 1f;
    CircleCollider2D circleCollider2D;
    private void Awake()
    {
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
        circleCollider2D.radius = expDropDistance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        transform.parent.GetComponent<expDrop>().MoveToTarget();
    }
}
