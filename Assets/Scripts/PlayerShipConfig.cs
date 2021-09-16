using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Projectile Configuration")]
public class PlayerShipConfig : ScriptableObject
{
    [SerializeField] GameObject ship;
    [SerializeField] GameObject projectile;
    [SerializeField] float timeBetweenShots = 0.1f;
    [SerializeField] float speedOfProjectile = 5f;
    [SerializeField] int damage = 10;
    [SerializeField] int health = 200;
    [SerializeField] float shipSpeed = 3f;

    public GameObject GetShipPrefab => ship;
    public GameObject PlayerProjectilePferab => projectile;
    public float TimeBetweenShots => timeBetweenShots;
    public float SpeedOfProjectile => speedOfProjectile;
    public int DamageProjectile => damage;
    public int GetHealth => health;
    public float GetShipSpeed => shipSpeed;
}
