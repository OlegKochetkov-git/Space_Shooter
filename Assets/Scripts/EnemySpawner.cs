using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyConfig> enemyConfigs;
    [SerializeField] float timeBetweenWaveSpawn = 0.5f;

    List<Vector2> path;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWave());

        }
        while (true);
    }

    IEnumerator SpawnAllWave()
    {
        for (int waveIndex = 0; waveIndex < enemyConfigs.Count; waveIndex++)
        {
            var currentWave = enemyConfigs[waveIndex];
            yield return StartCoroutine(SpawnSingleWave(currentWave));
        }
    }

    IEnumerator SpawnSingleWave(EnemyConfig enemyConfig)
    {
        if (path != null) { path = null; }

        for (int i = 0; i < enemyConfig.GetEnemyNumber(); i++)
        {
            var enemy = enemyConfig;

            if (path == null) { path = enemyConfig.GetEnemyPath(); }

            int positionInFirstZone = 0;
            var obj = Instantiate(enemy.GetEnemyPrefab(), path[positionInFirstZone], transform.rotation);
            obj.GetComponent<Enemy>().SetEnemyConfig(enemy);
            obj.GetComponent<Enemy>().SetEnemyPath(path);

            yield return new WaitForSeconds(enemy.GetTimeBetweenSpawn());
        }

        yield return new WaitForSeconds(timeBetweenWaveSpawn);
  
    } 

}
