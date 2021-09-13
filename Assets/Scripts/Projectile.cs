using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    PlayerWeaponConfig playerWeaponConfig;
    EnemyConfig enemyConfig;
    Animator animator;
    Rigidbody2D rb;

    int damage;
    bool isEnemyProjectile;
    float collisionSpeed = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (enemyConfig != null)
        {
            isEnemyProjectile = enemyConfig.GetIsEnemyProjectile();
            damage = enemyConfig.GetDamage();
            rb.velocity = new Vector2(enemyConfig.GetEnemyProjectileSpeed(), 0);
        }

        if (playerWeaponConfig != null)
        {
            damage = playerWeaponConfig.GetDamageProjectile();
        }
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
            return;
        }
        
    }

    #region Set methods
    public void SetEnemyConfig(EnemyConfig enemyConfig)
    {
        this.enemyConfig = enemyConfig;
    }
    public void SetPlayerConfig(PlayerWeaponConfig playerWeaponConfig)
    {
        this.playerWeaponConfig = playerWeaponConfig;
    }
    #endregion


    #region Set methods used in Animator
    public void SetSpeedProjectileZero()
    {
        rb.velocity = new Vector2(collisionSpeed, collisionSpeed);
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    #endregion
}
