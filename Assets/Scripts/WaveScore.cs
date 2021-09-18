using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScore : MonoBehaviour
{
    float enemyKills;
    bool isNextShip;

    void Start()
    {
        GetComponent<Slider>().value = enemyKills;
    }

    void Update()
    {

        //TODO come up with something to GetComponent not be in the update
        GetComponent<Slider>().value = enemyKills;
        if (GetComponent<Slider>().value == 5 && !isNextShip)
        {
            isNextShip = true;
            FindObjectOfType<ShipsManager>().RespawnSecondShip();
        }
    }

    public void CounterEnemyKills(float enemyKills)
    {
        this.enemyKills += enemyKills;
    }


}
