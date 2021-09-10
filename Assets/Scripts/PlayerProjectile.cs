using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    float damage;
    float collisionSpeed = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            var health = collision.GetComponent<Health>();
            animator.SetTrigger("Collision");
            health.GetDamage(damage);       
        }
    }

    #region public methods used in the animator
    public void SetSpeedProjectileCollision()
    {
        rb.velocity = new Vector2(collisionSpeed, collisionSpeed);
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    #endregion
}
