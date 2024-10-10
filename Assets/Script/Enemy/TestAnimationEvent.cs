using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform firstAttack;
    public void enabledFirstAttack()
    {
        firstAttack.gameObject.SetActive(true);
        // Debug.Log("firstAttack.hitBox.enabled = TRUE");

    }
    public void disableFirstAttack()
    {
        // firstAttack.hitBox.enabled = false;
        firstAttack.gameObject.SetActive(false);

        // Debug.Log("firstAttack.hitBox.enabled = FALSE");

    }
    public void DestroySelf()
    {
        ProjectileSpawner.Instance.DespawnOjb(transform);
    }
}
