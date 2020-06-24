using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject dart;
    public int ammo = 0;

    private Camera playerCam;
    private Transform playerArm;
    private Transform crosshair;
    private bool keyboardMouseControls = false;
    private bool OVRControls = false;
    private bool gameStarted = false;

    private HUDScript hudScript;

    private const float CONTROLLER_SENSITIVITY = 400;

    public void StartGame()
    {
        if (!gameStarted)
        {
            GameManager gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
            gameManager.timerOn = true;
        }
    }

    public void ThrowDart()
    {
        if (dart == null)
        {
            Debug.LogError("The dart object has not been assigned.");
            return;
        }

        if (ammo > 0)
        {
            if (playerArm == null || crosshair == null)
            {
                Debug.LogError("Cannot find crosshair reference.");
                return;
            }

            Vector3 throwDirection = crosshair.position - playerArm.position;
            GameObject newDart = Instantiate(dart);
            newDart.transform.position = playerArm.transform.position;
            newDart.GetComponent<DartScript>().Shoot(throwDirection);
            ammo--;
            hudScript.UpdateAmmoHUD();
        }
    }

    private void CheckForInteractables(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Pickup"))
            {
                ammo = hudScript.defaultAmmoCount;
                hudScript.UpdateAmmoHUD();
            }
            else
            {
                ThrowDart();
            }
        }
        else
        {
            ThrowDart();
        }
    }

    private void ProcessInputs()
    {
        if (keyboardMouseControls)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos += crosshair.localPosition;
            crosshair.position = Camera.main.ScreenToWorldPoint(mousePos);

            if (Input.GetMouseButtonDown(0))
            {
                ThrowDart();
            }
        }
        else if (OVRControls)
        {
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.GetActiveController());
            playerArm.rotation = Quaternion.RotateTowards(playerArm.rotation, controllerRotation, CONTROLLER_SENSITIVITY * Time.deltaTime);

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Ray ray = new Ray(playerArm.position, playerArm.transform.forward);

                CheckForInteractables(ray);
            }
        }
    }

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            keyboardMouseControls = true;

        else if (Application.platform == RuntimePlatform.Android)
            OVRControls = true;

        HUDScript hudScript = (HUDScript)FindObjectOfType(typeof(HUDScript));
    }

    private void Start()
    {
        playerCam = Camera.main;
        playerArm = transform.Find("Arm");
        crosshair = playerArm.Find("Crosshair");
    }

    private void Update()
    {
        ProcessInputs();
    }
}