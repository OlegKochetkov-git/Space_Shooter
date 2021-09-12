using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject gun;

    EnemyConfig enemyConfig;
    List<Vector2> path;
    Animator animator;

    

    int wayPoint = 1;
    float shotCountDown;
    int health;

    void Start()
    {
        shotCountDown = enemyConfig.GetTimeBetweenShots();
        health = enemyConfig.GetHealth();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        CountDownShots();
    }

    #region Set methods
    public void SetEnemyConfig(EnemyConfig enemyConfig)
    {
        this.enemyConfig = enemyConfig;
    }
    public void SetEnemyPath(List<Vector2> path)
    {
        this.path = path;
    }
    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    void CountDownShots()
    {
        shotCountDown -= Time.deltaTime;
        if (shotCountDown <= 0f)
        {
            Fire();
            shotCountDown = enemyConfig.GetTimeBetweenShots();
        }
    }

    void Fire()
    {
        animator.SetTrigger("Initial Shot");

        //var laser = Instantiate(enemyConfig.GetEnemyProjectile(), gun.transform.position, Quaternion.identity);
        //laser.GetComponent<Projectile>().SetEnemyConfig(enemyConfig);
        
        
        //laser.GetComponent<Projectile>().SetIsEnemyProjectile(true);
        //laser.GetComponent<Projectile>().SetAnimationName(enemyConfig.GetAnimationProjectileName());
        //laser.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyConfig.GetEnemyProjectileSpeed(), 0f);
        //laser.GetComponent<Projectile>().SetDamage(enemyConfig.GetDamage());
    }

    // in animator
    public void FireAnimation()
    {
        var laser = Instantiate(enemyConfig.GetEnemyProjectile(), gun.transform.position, Quaternion.identity);
        laser.GetComponent<Projectile>().SetEnemyConfig(enemyConfig);
    }

    void Move()
    {
        if (wayPoint < path.Count)
        {
            var targetPosition = path[wayPoint];
            var movementThisFrame = enemyConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if ((Vector2)transform.position == targetPosition)
            {
                wayPoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
