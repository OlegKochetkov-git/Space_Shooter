using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScore : MonoBehaviour
{
    float enemyKills;

    
    void Update()
    {
        GetComponent<Slider>().value = enemyKills;
    }

    public void CounterEnemyKills(float enemyKills)
    {
        this.enemyKills += enemyKills;
    }
}
