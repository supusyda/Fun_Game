using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrewTriggerArgo : MonoBehaviour
{
    // Start is called before the first frame update
    AllyBase ally;

    [SerializeField] List<Transform> targets = new();

    [SerializeField] public bool ISMOREENEMY;

    private void Update()
    {

    }
    private void Awake()
    {
        ally = GetComponentInParent<AllyBase>();

    }
    private void OnEnable()
    {

        targets.Clear();
        ally.target = null;
        ally.setIsArgo(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ally.setIsArgo(true);
            ally.SetTarget(other.transform);
            targets.Add(other.transform);

            // collider2D.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //when enemy get out of attack range or die then change target
            targets.Remove(other.transform);
            if (targets.Count > 0)
            {
                ally.SetTarget(targets[0]);
            }
            else
            {
                ally.SetTarget(null);
                ally.setIsArgo(false);
                targets.Clear();
            }
        }
    }
}
