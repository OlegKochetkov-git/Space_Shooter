using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    EnemyConfig enemyConfig;
    List<Vector2> path;

    int wayPoint = 1;



    public void SetEnemyConfig(EnemyConfig enemyConfig)
    {
        this.enemyConfig = enemyConfig;
    }

    public void SetEnemyPath(List<Vector2> path)
    {
        this.path = path;
    }

    void Update()
    {
        if (wayPoint < path.Count)
        {
            var targetPosition = path[wayPoint]; // начала движение
            var movementThisFrame = enemyConfig.GetEnemySpeed() * Time.deltaTime; // скорость 
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





        //transform.position = Vector2.MoveTowards(transform.position, path[1], enemyConfig.GetEnemySpeed() * Time.deltaTime);

        //if ((Vector2)transform.position == path[1])
        //{
            
        //}
        


    }

}
