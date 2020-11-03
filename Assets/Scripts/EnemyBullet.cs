using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount = 10;

    public float bulletSpeed = 3;

    public Rigidbody bulletRB;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerMovement.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().takeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
