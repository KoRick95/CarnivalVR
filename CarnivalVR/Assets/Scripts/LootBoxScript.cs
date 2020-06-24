using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour
{
    public List<GameObject> rarities;
    public List<float> probabilities;

    private PrizesManager prizesManager;

    private void Start()
    {
        if (rarities.Count != probabilities.Count)
            Debug.LogWarning("The number of rarities do not match the number of probabilities.");

        DrawPrize();
    }

    public void DrawPrize()
    {
        // calculate total probability
        float totalProbability = 0;
        for (int i = 0; i < probabilities.Count; ++i)
        {
            if(probabilities[i] < 0)
            {
                Debug.LogError("One of the probabilities are negative. A probability cannot be negative.");
                return;
            }

            totalProbability += probabilities[i];
        }

        // use random number generator to determine the rarity of the prize
        float rng = Random.Range(0, totalProbability);
        int index;
        for (index = 0; index < probabilities.Count; ++index)
        {
            rng -= probabilities[index];

            if (rng < 0)
                break;
        }

        // draw a random prize from that rarity's prize pool
        GameObject rarity = rarities[index];
        GameObject prize = rarity.GetComponent<RarityScript>().RandomizePrize();

        // instantiate the prize
        if (prize != null)
        {
            prizesManager = (PrizesManager)FindObjectOfType(typeof(PrizesManager));

            if (prizesManager != null)
            {
                prizesManager.ObtainPrize(prize);
            }
        }

        Destroy(this.gameObject);
    }
}