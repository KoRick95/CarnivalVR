using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPointer : MonoBehaviour
{
    public Camera cam;
    public float maximumLength;

    private Ray rayPointer;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var pointerPos = Input.mousePosition;
            rayPointer = cam.ScreenPointToRay(pointerPos);
            if (Physics.Raycast(rayPointer.origin, rayPointer.direction, out hit, maximumLength))
            {
                RotateToPointerDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayPointer.GetPoint(maximumLength);
                RotateToPointerDirection(gameObject, hit.point);
            }
        }
        else
        {
            Debug.Log("No camera");
        }
    }

    void RotateToPointerDirection (GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        //Disabled because of incompatibility with already existing camera rotating the darts
        //obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
