using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartWeapon : MonoBehaviour
{
    public SpawnProjectile spawnProjectile;

    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float speed = 1000f;

    public Camera fpsCam;
    public GameObject impactEffect;
    public GameObject dart1;
    public GameObject dart2;
    public GameObject dart3;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        ShowDartsInHand();
    }

    private void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Throw();
        }*/
    }

    public void Throw()
    {
        //Dart disappears from hand and lerps toward the crosshair direction
        if (PlayerStats.dartsHeld <= 0)
        {
            print("No darts");
            return;
        }
        else
        {
            PlayerStats.dartsHeld--;
            ShowDartsInHand();
            spawnProjectile.SpawnDart();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Balloon target = hit.transform.GetComponent<Balloon>();
                if (target != null)
                {
                    target.AddScore();
                    print(PlayerStats.currentScore);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                //Dart impact
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }

    public void ShowDartsInHand()
    {
        if (PlayerStats.dartsHeld == 0)
        {
            dart1.SetActive(false);
            dart2.SetActive(false);
            dart3.SetActive(false);
        }
        else if (PlayerStats.dartsHeld == 1)
        {
            dart1.SetActive(true);
            dart2.SetActive(false);
            dart3.SetActive(false);
        }
        else if (PlayerStats.dartsHeld == 2)
        {
            dart1.SetActive(true);
            dart2.SetActive(true);
            dart3.SetActive(false);
        }
        else if (PlayerStats.dartsHeld == 3)
        {
            dart1.SetActive(true);
            dart2.SetActive(true);
            dart3.SetActive(true);
        }
    }
}
