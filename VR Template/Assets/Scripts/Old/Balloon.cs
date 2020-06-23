using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int scoreValue;

    public void AddScore()
    {
        PlayerStats.currentScore += scoreValue;
        Pop();
    }

    void Pop()
    {
        Destroy(gameObject);
    }
}
