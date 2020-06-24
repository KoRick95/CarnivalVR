using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizesManager : MonoBehaviour
{
    public List<GameObject> prizes;

    private List<GameObject> obtainedPrizes;

    public void ObtainPrize(GameObject prize)
    {
        // check if the prize obtained is on the master list
        if (!prizes.Contains(prize))
        {
            Debug.LogError("That prize does not exist.");
            return;
        }

        // check if the prize has already been previously obtained
        if (obtainedPrizes.Count > 0 && !obtainedPrizes.Contains(prize))
        {
            Instantiate(prize);
            obtainedPrizes.Add(prize);
            Debug.Log(prize);
        }
    }

    private void Start()
    {
        obtainedPrizes = new List<GameObject>();
    }
}