using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class EnemyController : MonoBehaviour
{
    public int health = 3;

    public GameObject explosionFX;

    public float playerRange = 5f;

    public Rigidbody EnemyRb;

    public float moveSpeed;

    public bool shouldShoot = true;

    public float fireRate = 0.5f;

    public float shotCounter;

    public GameObject bullet;

    public Transform firePoint;


    private void Start()
    {
        shouldShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerMovement.instance.transform.position - transform.position;

            EnemyRb.velocity = playerDirection.normalized * moveSpeed;

            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter<=0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else
        {
            EnemyRb.velocity = Vector3.zero;
        }
    }

    public void takeDamage()
    {
        health--;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionFX, transform.position, transform.rotation);
        }
    }
}
