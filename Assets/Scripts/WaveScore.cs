using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScore : MonoBehaviour
{
    float enemyKills;
    float maxSlideValue;
    int shipIndex;

    void Start()
    {
        GetComponent<Slider>().value = enemyKills;
        maxSlideValue = GetComponent<Slider>().maxValue;
    }

    void Update()
    {

        //TODO come up with something to GetComponent not be in the update
        GetComponent<Slider>().value = enemyKills;

        if (GetComponent<Slider>().value == maxSlideValue)
        {
            StartCoroutine(SpawnNextShip());

            enemyKills = 0;
            GetComponent<Slider>().value = 0;
            
        }
    }

    public void CounterEnemyKills(float enemyKills)
    {
        this.enemyKills += enemyKills;
    }

    IEnumerator SpawnNextShip()
    {
        if (shipIndex < 2)
        {
            shipIndex++;
            FindObjectOfType<ShipsManager>().RespawnSecondShip(shipIndex);
        }

        yield return new WaitForEndOfFrame();
    }

}
