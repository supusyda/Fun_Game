using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArgo : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyBase _enemy;
    [SerializeField] List<Transform> targets = new();

    private void Awake()
    {
        _enemy = GetComponentInParent<EnemyBase>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CanInteract(other))
        {
            _enemy.setIsArgo(true);
            _enemy.target = other.transform;
            targets.Add(other.transform);
            // collider2D.enabled = false;
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (CanInteract(other))
        {


            targets.Remove(other.transform);


            if (targets.Count > 0)
            {
                _enemy.SetTarget(targets[0]);
            }
            else
            {
                _enemy.SetTarget(null);
                _enemy.setIsArgo(false);
                targets.Clear();
            }
            // enemy.target = null;

            // collider2D.enabled = true;
        }
    }

    bool CanInteract(Collider2D other)
    {
        return other.CompareTag(PlayerDefine.PLAYER_TAG) || other.CompareTag(PlayerDefine.CREW_TAG);
    }
}
