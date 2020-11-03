using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot instance;

    public Camera mainCamera;

    public GameObject bulletImpact;

    public int currentAmmo = 10;

    public Animator gunAnim;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                    //Debug.Log("I'm looking at " + hit.transform.name);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyController>().takeDamage();
                    }
                }
                else
                {
                    Debug.Log("I'm looking at nothing");
                }
                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
            }
        }
    }
}
