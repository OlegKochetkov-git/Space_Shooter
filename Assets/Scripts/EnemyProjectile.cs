using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Player>()) { return; }
        other.GetComponent<Player>().GetDamage(damage);
    }
}
