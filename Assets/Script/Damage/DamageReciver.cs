using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    protected virtual async void KnockBack(Vector2 knockbackVecter)
    {
        // rigidbody2D.velocity = new Vector2(knockbackVecter.x, knockbackVecter.y);


        rigidbody2D.AddForce(knockbackVecter, ForceMode2D.Impulse);
        await Task.Delay(1000);//reset velocity after 1sec
        if (!rigidbody2D) return;
        rigidbody2D.velocity = Vector2.zero;
    }
    public virtual void TakeDamage(float damage, Vector2 knockbackVecter)
    {

        this.KnockBack(knockbackVecter);
        this.DeduceHp(damage);
        this.hitAnim();
        

    }
  

    protected virtual void DeduceHp(float reduceHP)
    {

        if (isAlive)
        {
            this.Hp = this.Hp - reduceHP;
            if(this.Hp <= 0) Die();

        }
    }
    protected virtual void hitAnim()
    {

    }
     protected virtual void Die(Action<string> callback=null)
    {

    }
}
