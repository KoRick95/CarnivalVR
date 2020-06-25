using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public ScoreScript scoreScript;

    public Text scoreNumber;

    void Update()
    {
        scoreNumber.text = scoreScript.score.ToString();
    }
}
