using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject dart;

    private Camera playerCam;
    private bool keyboardMouseControls = false;
    private bool OVRControls = false;

    public void ThrowDart()
    {
        if (dart == null)
        {
            Debug.LogError("The dart object has not been assigned.");
            return;
        }

        GameObject newDart = Instantiate(dart);
        newDart.transform.position = this.transform.position;
        newDart.GetComponent<DartScript>().Shoot(playerCam.transform.forward);
    }

    private void ProcessInputs()
    {
        if (keyboardMouseControls)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ThrowDart();
            }
        }
        else if (OVRControls)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                ThrowDart();
            }
        }
    }

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            keyboardMouseControls = true;

        else if (Application.platform == RuntimePlatform.Android)
            OVRControls = true;
    }

    private void Start()
    {
        playerCam = Camera.main;
    }

    private void Update()
    {
        ProcessInputs();
    }
}
