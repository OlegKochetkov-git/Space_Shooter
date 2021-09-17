using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerShipConfig ship;
    [SerializeField] GameObject gun;

    [Header("Set in ScriptableObjects")]
    [SerializeField] int health;
    [Space]

    [SerializeField] float padding = 1f;

    Coroutine firingCoroutin;
    Animator animator;

    float xMin;
    float xMax;
    float yMax;
    float yMin;

    void Start()
    {
        health = ship.GetHealth;
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("Explosion");
            
        }  
    }

    public void SetShipConfig(PlayerShipConfig ship)
    {
        this.ship = ship;
    }

    void DestroyShip()
    {
        Destroy(gameObject);
    }
    
    void Move()
    {
        var movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * ship.GetShipSpeed;
        var movementY = Input.GetAxisRaw("Vertical") * Time.deltaTime * ship.GetShipSpeed;

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
            firingCoroutin = StartCoroutine(PermanentlyFire());
        }

        if (Input.GetButtonUp("Fire1"))
        { 
            StopCoroutine(firingCoroutin);
        }
    }

    IEnumerator PermanentlyFire()
    {
        while (true)
        {
            animator.SetTrigger("Initial Shot");

            yield return new WaitForSeconds(ship.TimeBetweenShots);
        }     
    }

    #region Public methods use in animator
    public void Shot()
    {
        GameObject projectile = Instantiate(ship.PlayerProjectilePferab, gun.transform.position, Quaternion.Euler(0f, 0f, 0f));
        projectile.GetComponent<Projectile>().SetPlayerConfig(ship);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(ship.SpeedOfProjectile, 0);
    }
    #endregion


}
