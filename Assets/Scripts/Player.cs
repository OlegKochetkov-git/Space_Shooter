using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerWeaponConfig defaultWeapon;
    [SerializeField] PlayerWeaponConfig secondWeapon;
    [SerializeField] GameObject gun;
    [SerializeField] int health = 50;
    
    [SerializeField] float speed = 3f;
    [SerializeField] float padding = 1f;

    Coroutine firingCoroutin;

    float xMin;
    float xMax;
    float yMax;
    float yMin;

    bool isButtonDown;

    void Start()
    {
        ScreenBorders();
    }

    
    void Update()
    {
        Move();
        Fire();
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    
    void Move()
    {
        var movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        var movementY = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        var newPosX = Mathf.Clamp(transform.position.x + movementX, xMin, xMax);
        var newPosY = Mathf.Clamp(transform.position.y + movementY, yMin, yMax);

        transform.position = new Vector2(newPosX, newPosY);
    }

    void ScreenBorders()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Fire()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            isButtonDown = true;
            firingCoroutin = StartCoroutine(PermanentlyFire(defaultWeapon));
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isButtonDown = true;
            firingCoroutin = StartCoroutine(PermanentlyFire(secondWeapon));
        }


        if (Input.GetButtonUp("Fire1"))
        {
            isButtonDown = false;
            StopCoroutine(firingCoroutin);

        }

        if (Input.GetButtonUp("Fire2"))
        {
            isButtonDown = false;
            StopCoroutine(firingCoroutin);

        }

    }

    IEnumerator PermanentlyFire(PlayerWeaponConfig weapon)
    {
        while (isButtonDown)
        {
            GameObject projectile = Instantiate(weapon.GetPlayerProjectilePferab(), gun.transform.position, Quaternion.Euler(0f, 0f, 90f));
            //projectile.GetComponent<Projectile>().SetDamage(weapon.GetDamageProjectile());
            projectile.GetComponent<Projectile>().SetPlayerConfig(weapon);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(weapon.GetSpeedOfProjectile(), 0);
            
            yield return new WaitForSeconds(weapon.GetTimeBetweenShots());
        }     
    }

    
}
