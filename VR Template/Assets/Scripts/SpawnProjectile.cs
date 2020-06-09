using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject dartProjPrefab;
    public RotateToPointer rotateToPointer;

    private GameObject dartToSpawn;

    private void Start()
    {
        dartToSpawn = dartProjPrefab;
    }
    public void SpawnDart()
    {
        GameObject dart;

        if (firePoint != null)
        {
            dart = Instantiate(dartToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToPointer != null)
            {
                dart.transform.localRotation = rotateToPointer.GetRotation();
            }
        }
        else
        {
            Debug.Log("No fire point");
        }
    }
}
