using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawnerScript : MonoBehaviour
{
    public List<GameObject> spawnObjects;

    public int spawnNumber = 0;

    // the number of rows and columns for the spawn grids
    public int rows = 1;
    public int columns = 1;

    // the dimensions of the rectangular spawn area
    public float width = 0;
    public float height = 0;

    // if set to true, then spawn in the opposite direction
    // does nothing atm
    public bool invertSpawnDirection = false;

    // the start point of the spawn grid
    private Vector3 startPoint;

    // the distances between each spawn point
    private float distX;
    private float distY;

    // holds the available spawn location indexes
    private List<int> spawnIndexes;

    public void Spawn()
    {
        if (spawnObjects.Count == 0)
        {
            Debug.LogError("Spawn object has not been assigned.");
        }

        for (int i = 0; i < spawnNumber; ++i)
        {
            // randomly choose a spawn index
            int n = Random.Range(0, spawnIndexes.Count);
            int index = spawnIndexes[n];

            // remove the chosen index from the list as it is now being used
            spawnIndexes.RemoveAt(n);

            // identify which row and column the spawn point is in
            int row = index / columns;
            int col = index % columns;

            // calculate the exact spawn location
            Vector3 spawnPoint = startPoint + new Vector3(distX * (row + 0.5f), distY * (col + 0.5f));

            // randomly choose an object to spawn from the pool of spawn objects
            GameObject spawnObject = spawnObjects[Random.Range(0, spawnObjects.Count)];

            // spawn the object at the precalculated location
            GameObject newSpawn = Instantiate(spawnObject);
            newSpawn.transform.SetParent(this.transform);
            newSpawn.transform.position = spawnPoint;
        }
    }

    private void OnValidate()
    {
        spawnNumber = Mathf.Min(spawnNumber, rows * columns);
        rows = Mathf.Max(1, rows);
        columns = Mathf.Max(1, columns);
        width = Mathf.Max(0, width);
        height = Mathf.Max(0, height);
    }

    private void Start()
    {
        spawnIndexes = new List<int>(rows * columns);

        for (int i = 0; i < rows * columns; ++i)
            spawnIndexes.Add(i);

        distX = width / columns;
        distY = height / rows;

        startPoint = this.transform.position;

        // testing...
        //Spawn();
    }
}
