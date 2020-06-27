using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float defaultGameTime = 30;
    public bool timerOn = false;

    public List<GameObject> lootBoxes;

    private PlayerScript playerScript;
    private ScoreScript scoreScript;
    private float timer = 0;

    public void GetLootBox()
    {
        // check the player's score
        float playerScore = scoreScript.score;

        if (playerScore < 50)
        {
            // player does not get a lootbox
            return;
        }
        else if (playerScore >= 50 && playerScore < 150)
        {
            // player gets a common lootbox
            Instantiate(lootBoxes[0]);
        }
        else if (playerScore >= 150 && playerScore < 300)
        {
            // player gets a rare lootbox
            Instantiate(lootBoxes[1]);
        }
        else if (playerScore >= 300)
        {
            // player gets a super rare lootbox
            Instantiate(lootBoxes[2]);
        }

        return;
    }

    private void Start()
    {
        playerScript = (PlayerScript)FindObjectOfType(typeof(PlayerScript));
        scoreScript = (ScoreScript)FindObjectOfType(typeof(ScoreScript));

        timer = defaultGameTime;
    }

    private void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                // instantiate the lootbox
                GetLootBox();
                /*if (lootbox != null)
                {
                    Instantiate(lootbox);
                }*/

                timerOn = false;
                timer = defaultGameTime;
                Debug.Log("Time over");
            }
        }
    }
}
