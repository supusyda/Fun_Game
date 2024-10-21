using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class DamageReciver : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody2D;
    [SerializeField] protected Collider2D collider2D;//hurt box
    [SerializeField] HeathBar healthBar;
    [SerializeField] public float hp;
    protected Vector2 knockBackVector;
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
    protected virtual void Awake()
    {
        rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
        if (collider2D) return;
        collider2D = transform.parent.GetComponent<Collider2D>();
    }
    protected virtual void OnEnable()
    {
        // animator = GetComponent<Animator>();
        init();
    }
    void init()
    {
        this.Hp = this.maxHp;
        this.IsAlive = true;
        collider2D.enabled = true;
    }
    protected virtual async void KnockBack(Vector2 knockbackVecter)
    {
        // rigidbody2D.velocity = new Vector2(knockbackVecter.x, knockbackVecter.y);

        if (!rigidbody2D) return;

        rigidbody2D.AddForce(knockbackVecter, ForceMode2D.Impulse);
        await Task.Delay(1000);//reset velocity after 1sec
        if (!rigidbody2D) return;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0;
    }
    public virtual void TakeDamage(float damage, Vector2 knockbackVecter)
    {

        this.KnockBack(knockbackVecter);
        this.DeduceHp(damage);
        this.hitAnim();
        hitParticle(knockbackVecter);
    }


    protected virtual void DeduceHp(float reduceHP)
    {

        if (isAlive)
        {
            this.Hp = this.Hp - reduceHP;
            healthBar?.SetHealth((int)Hp);
            if (this.Hp <= 0) Die();

        }
    }
    protected virtual void hitParticle(Vector2 particelDir)
    {

    }

    protected virtual void hitAnim()
    {

    }
    protected virtual void Die(Action<string> callback = null)
    {
        Debug.Log("DIE");
    }
    protected virtual void Die()
    {
        Debug.Log("DIE");

    }
    public void SetMaxHP(float maxHP)
    {
        this.maxHp = maxHP;

        healthBar.SetHPbarToMaxHP((int)maxHP);

    }
    public void addHP(float amount)
    {
        if (!isAlive) return;
        this.Hp = math.clamp(this.Hp + amount, 0, maxHp);
        healthBar?.SetHealth((int)Hp);
    }
}
