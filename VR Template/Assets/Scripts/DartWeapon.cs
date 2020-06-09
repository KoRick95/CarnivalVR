using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartWeapon : MonoBehaviour
{
    public float range = 100f;

    public Camera fpsCam;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Throw();
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
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Balloon target = hit.transform.GetComponent<Balloon>();
                if (target != null)
                {
                    target.AddScore();
                    print(PlayerStats.currentScore);
                }
            }
        }
    }
}
