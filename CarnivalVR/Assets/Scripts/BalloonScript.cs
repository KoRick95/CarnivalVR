using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float scoreValue = 5;

    public void Pop()
    {
        ScoreScript scoreScript = (ScoreScript)FindObjectOfType(typeof(ScoreScript));
        scoreScript.score += scoreValue;
        Destroy(this.gameObject);
    }
}
