using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxAnimTesting : MonoBehaviour
{
    public Animation anim;

    private void OnMouseUpAsButton()
    {
        anim.Play("OpenLootBox");
    }
}
