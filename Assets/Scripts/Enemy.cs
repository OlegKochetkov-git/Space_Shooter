using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    EnemyConfig enemyConfig;
    List<Vector2> path;

    int wayPoint = 1;
    float shotCount;

    void Start()
    {
        shotCount = enemyConfig.GetTimeBetweenShots();
    }

    void Update()
    {
        Move();
        CountDown();
    }


    public void SetEnemyConfig(EnemyConfig enemyConfig)
    {
        this.enemyConfig = enemyConfig;
    }
    public void SetEnemyPath(List<Vector2> path)
    {
        this.path = path;
    }

    void CountDown()
    {
        shotCount -= Time.deltaTime;
        if (shotCount <= 0f)
        {
            Fire();
            shotCount = enemyConfig.GetTimeBetweenShots();
        }

    }

    void Fire()
    {
        var laser = Instantiate(enemyConfig.GetEnemyProjectile(), transform.position, Quaternion.Euler(0f,0f,90f));
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyConfig.GetEnemyProjectileSpeed(), 0f);

        
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
