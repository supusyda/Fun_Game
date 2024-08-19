using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerAttackInRange : MonoBehaviour
{
    // Start is called before the first frame update
    
   protected Collider2D collider2D;
    protected virtual void Awake() {
        // enemy = GetComponentInParent<EnemyBase>();
        collider2D = GetComponent<Collider2D>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other) {
        // if (other.CompareTag("Player")) {
        //     enemy.setAttackWithInRange(true);
         
        // }
    }
    protected virtual void OnTriggerExit2D(Collider2D other) {
        // if (other.CompareTag("Player")) {
        //     enemy.setAttackWithInRange(false);
           
        // }
    }
}
