using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    public GameObject ui;

    public void OnMouseUpAsButton()
    {
        ui.SetActive(!ui.activeSelf);
    }
}
