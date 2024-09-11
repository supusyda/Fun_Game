using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform dropPrefab;
    public void Drop()
    {
        Instantiate(dropPrefab, transform.parent.position, Quaternion.identity).gameObject.SetActive(true);
    }
}
