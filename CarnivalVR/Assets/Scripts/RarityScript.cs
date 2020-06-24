using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RarityScript : MonoBehaviour
{
    public string rarityName = "";
    public List<GameObject> prizePool;

    public GameObject RandomizePrize()
    {
        int index = Random.Range(0, prizePool.Count);

        return prizePool[index];
    }
}