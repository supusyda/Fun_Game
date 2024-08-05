using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciver : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody2D;
    Collider2D collider2D;
    [SerializeField] protected float hp;
    protected float Hp
    {
        set
        {
            hp = value;
            if (this.hp <= 0)
            {
                IsAlive = false;
                collider2D.enabled = false;
                // Defeated();

            }
        }
        get => hp;
    }
    public float maxHp;
    public bool isAlive;
    protected bool IsAlive
    {
        set
        {
            isAlive = value;
            // animator.SetBool("isAlive", value);
        }
        get => isAlive;
    }
    protected virtual void Start()
    {
        // animator = GetComponent<Animator>();
        this.Hp = this.maxHp;

        this.IsAlive = true;
        rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
        collider2D = transform.parent.GetComponent<Collider2D>();
    }
    protected virtual void KnockBack(Vector2 knockbackVecter)
    {
        rigidbody2D.velocity = new Vector2(knockbackVecter.x, rigidbody2D.velocity.y + knockbackVecter.y);
    }
    public virtual void TakeDamage(float damage, Vector2 knockbackVecter)
    {

        this.KnockBack(knockbackVecter);
        this.DeduceHp(damage);
        this.hitAnim();
        // this.animator.SetTrigger("getHit");

    }

    protected virtual void DeduceHp(float reduceHP)
    {

        if (isAlive)
        {
            this.Hp = this.Hp - reduceHP;

        }
    }
    protected virtual void hitAnim()
    {

    }
}
