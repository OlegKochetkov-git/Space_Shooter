using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Configuration")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GenerateRandomPosInArea> randomPos;
    [SerializeField] float speed;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float timeBetweenSpawn;
    

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Vector2> GetEnemyPath()
    {
        var enemyPath = new List<Vector2>(); 
        foreach (GenerateRandomPosInArea item in randomPos)
        {
            if(item.GetComponent<GenerateRandomPosInArea>())
            {
                var pos = item.GetComponent<GenerateRandomPosInArea>().GetRandomPosInArea();
                enemyPath.Add(pos);
            }
            
        }

        return enemyPath;
    }
    public float GetEnemySpeed() { return speed; }
    public float GetEnemyAmount() { return numberOfEnemies; }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }

    


}
