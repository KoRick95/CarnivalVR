using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public List<GameObject> ammoIndicator;
    public int defaultAmmoCount = 3;

    private PlayerScript playerScript;

    public void UpdateAmmoHUD()
    {
        if (playerScript.ammo > ammoIndicator.Count)
        {
            Debug.LogWarning("Player has more ammo than allowed.");
            playerScript.ammo = ammoIndicator.Count;
        }

        int i;

        for (i = 0; i < playerScript.ammo; ++i)
        {
            ammoIndicator[i].SetActive(true);
        }

        for (i = i; i < ammoIndicator.Count; ++i)
        {
            ammoIndicator[i].SetActive(false);
        }
    }

    private void Start()
    {
        playerScript = (PlayerScript)FindObjectOfType(typeof(PlayerScript));
    }
}
