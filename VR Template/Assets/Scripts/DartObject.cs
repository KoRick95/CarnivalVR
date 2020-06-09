using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartObject : MonoBehaviour
{
    public void PickUp()
    {
        //Show dart like an FPS weapon
        if (PlayerStats.dartsHeld != 3)
            PlayerStats.dartsHeld = 3;
    }
}
