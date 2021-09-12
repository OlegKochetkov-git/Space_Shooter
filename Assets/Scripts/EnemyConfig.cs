using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Configuration")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] List<GenerateRandomPosInArea> randomPos;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] string animationProjectileName;
    [SerializeField] int damage = 10;
    [SerializeField] float projectileSpeed;
    [SerializeField] float minTimeBetweenShots = 0.1f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] int health = 200;
    [SerializeField] float speed;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float timeBetweenSpawn;

    bool isEnemyProjectile = true;


    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public GameObject GetEnemyProjectile() { return enemyProjectile; }
    public int GetDamage() { return damage; }
    public string GetAnimationProjectileName() { return animationProjectileName; }
    public int GetHealth() { return health; }
    public float GetTimeBetweenShots()
    {
        return Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    public float GetEnemyProjectileSpeed() { return -projectileSpeed; }  
    public float GetEnemySpeed() { return speed; }
    public float GetEnemyNumber() { return numberOfEnemies; }
    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }
    public bool GetIsEnemyProjectile() { return isEnemyProjectile; }
    public List<Vector2> GetEnemyPath()
    {
        var enemyPath = new List<Vector2>();

        foreach (GenerateRandomPosInArea item in randomPos)
        {
            if (item.GetComponent<GenerateRandomPosInArea>())
            {
                var pos = item.GetComponent<GenerateRandomPosInArea>().GetRandomPosInArea();
                enemyPath.Add(pos);
            }

        }

        return enemyPath;
    }

}
