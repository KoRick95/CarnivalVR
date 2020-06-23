using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity = 15;

    private bool keyboardMouseControls = false;
    private bool OVRControls = false;

    private void OnValidate()
    {
        sensitivity = Mathf.Max(0, sensitivity);
    }

    private void Awake()
    {
        // detect which platform the player is running the game
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            keyboardMouseControls = true;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            OVRControls = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = this.transform.rotation.eulerAngles;

        // rotate the camera based on mouse position
        rotation.x += -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        this.transform.rotation = Quaternion.Euler(rotation);
    }
}
