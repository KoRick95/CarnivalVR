using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DartScript : MonoBehaviour
{
    public float speed = 100;
    public float deleteTimer = 10;

    private Rigidbody rb;
    private Vector3 defaultRotation;
    private Vector3 throwDirection;
    private bool fired = false;

    public void Shoot(Vector3 direction)
    {
        throwDirection = direction;
        transform.forward = direction;
        transform.Rotate(defaultRotation);
        fired = true;
    }

    private void Awake()
    {
        defaultRotation = this.transform.rotation.eulerAngles;//Debug.Log("euler: " + defaultRotation.x + "," + defaultRotation.y + "," + defaultRotation.z);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (fired)
        {
            Vector3 newPos = this.transform.position + throwDirection * speed * Time.deltaTime;
            rb.MovePosition(newPos);
            
            deleteTimer -= Time.deltaTime;

            if (deleteTimer < 0)
                Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Balloon"))
        {
            BalloonScript balloonScript = collision.collider.GetComponent<BalloonScript>();

            if (balloonScript != null)
                balloonScript.Pop();
            else
                Debug.LogError("Balloon script not found on the hit object.");
        }
        else
        {
            speed = 0;
            rb.isKinematic = true;
            rb.detectCollisions = false;
        }
    }
}