using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform cc;
    private void OnTriggerEnter2D(Collider2D other) {
        cc = other.transform;
    }
    private void OnTriggerExit2D(Collider2D other) {
        cc = null;
    }
}
