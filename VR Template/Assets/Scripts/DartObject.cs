using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartObject : MonoBehaviour
{
    public DartWeapon weaponHolder;
    public void PickUp()
    {
        //Show dart like an FPS weapon
        if (PlayerStats.dartsHeld > 0)
            return;
        else if (PlayerStats.dartsHeld == 0)
        {
            PlayerStats.dartsHeld = 3;
            weaponHolder.ShowDartsInHand();
        }
    }
}
