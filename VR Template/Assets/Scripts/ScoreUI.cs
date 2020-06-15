using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreNumber;

    private void Update()
    {
        scoreNumber.text = "Score: " + PlayerStats.currentScore.ToString();
    }
}
