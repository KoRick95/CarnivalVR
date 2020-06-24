using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartPickUp : MonoBehaviour
{
    public HUDScript hudScript;
    public PlayerScript playerScript;
    public GameManager gameManager;
    public BalloonSpawnerScript balloonSpawnerScript;

    public void OnMouseUpAsButton()
    {
        playerScript.ammo = hudScript.defaultAmmoCount;
        hudScript.UpdateAmmoHUD();

        if (!gameManager.timerOn)
        {
            balloonSpawnerScript.Spawn();
            playerScript.StartGame();
            //gameManager.timerOn = true;
        }
    }
}
