using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject midPoint;
    public GameObject leftPoint;
    public GameObject rightPoint;

    public void MoveToMidPoint()
    {
        gameObject.transform.position = midPoint.transform.position;
    }

    public void MoveToLeftPoint()
    {
        gameObject.transform.position = leftPoint.transform.position;
    }

    public void MoveToRightPoint()
    {
        gameObject.transform.position = rightPoint.transform.position;
    }
}
