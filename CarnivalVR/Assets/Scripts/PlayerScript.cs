using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject dartToThrow;
    public GameObject crosshairDart;
    public GameObject heldDartHigh;
    public GameObject heldDartLow;
    public RawImage crosshairRawImage;
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
        if (dartToThrow == null)
        {
            Debug.LogError("The dart object has not been assigned.");
            return;
        }

        StartGame();

        if (ammo > 0)
        {
            if (playerArm == null || crosshair == null)
            {
                Debug.LogError("Cannot find crosshair reference.");
                return;
            }

            Vector3 throwDirection = crosshair.position - playerArm.position;
            GameObject newDart = Instantiate(dartToThrow);
            newDart.transform.position = playerArm.transform.position;
            newDart.GetComponent<DartScript>().Shoot(throwDirection);
            ammo--;

            if (hudScript != null)
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

    void UpdateAmmoVisuals()
    {
        if (ammo == 3)
        {
            crosshairDart.SetActive(true);
            heldDartHigh.SetActive(true);
            heldDartLow.SetActive(true);
            crosshairRawImage.gameObject.SetActive(false);
        }
        else if (ammo == 2)
        {
            crosshairDart.SetActive(true);
            heldDartHigh.SetActive(true);
            heldDartLow.SetActive(false);
        }
        else if (ammo == 1)
        {
            crosshairDart.SetActive(true);
            heldDartHigh.SetActive(false);
            heldDartLow.SetActive(false);
        }
        else if (ammo == 0)
        {
            crosshairDart.SetActive(false);
            heldDartHigh.SetActive(false);
            heldDartLow.SetActive(false);
            crosshairRawImage.gameObject.SetActive(true);
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
        UpdateAmmoVisuals();
        ProcessInputs();
    }
}