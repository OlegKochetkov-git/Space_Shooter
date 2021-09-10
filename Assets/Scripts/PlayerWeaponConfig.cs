using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Projectile Configuration")]
public class PlayerWeaponConfig : ScriptableObject
{
    [SerializeField] GameObject projectile;
    [SerializeField] float timeBetweenShots = 0.1f;
    [SerializeField] float speedOfProjectile = 5f;
    [SerializeField] float damage = 10f;


    public GameObject GetPlayerProjectilePferab() { return projectile; }
    public float GetTimeBetweenShots() { return timeBetweenShots; }
    public float GetSpeedOfProjectile() { return speedOfProjectile; }
    public float GetDamageProjectile() { return damage; }
}
