using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    int damage;
    float collisionSpeed = 0;
    bool isEnemyProjectile;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        try
        {
            if (isEnemyProjectile)
            {
                collider.GetComponent<Player>().GetDamage(damage);
                animator.SetTrigger("Collision");
            }
            else
            {
                collider.GetComponent<Enemy>().GetDamage(damage);
                animator.SetTrigger("Collision");
            }
        }
        catch (NullReferenceException)
        {
            if (!collider.GetComponent<Player>() || !collider.GetComponent<Enemy>())
            {
                return;
            }
            
        }
        
    }

    #region Set methods
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetIsEnemyProjectile(bool isEnemyProjectile)
    {
        this.isEnemyProjectile = isEnemyProjectile;
    }
    #endregion

    #region Set methods used in Animator
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
