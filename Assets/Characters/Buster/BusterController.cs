using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterController : MonoBehaviour
{
    public Rigidbody rb;

    float speeeeed = 1;
    public float baseSpeed = 2;
    public float editorSpeedMultiplier = 0.1f;
    public Vector2 inputDelay;

    public bool canMove = true;
    public bool pissedYourself = false;
    public Camera cam;

    private void Start()
    {
        RecalculateSpeed(1);
    }

    public void RecalculateSpeed(float speedMultiplier)
    {
        speeeeed = baseSpeed;

        speeeeed *= speedMultiplier;

#if UNITY_EDITOR
        speeeeed *= editorSpeedMultiplier;
#endif
    }

    public void BustAMove(int direction)
    {
        if (canMove)
        {
            StartCoroutine(IDelayMovement(Random.Range(inputDelay.x, inputDelay.y), direction));
        }
    }

    private void FixedUpdate()
    {
        if (pissedYourself == true)
        {
            rb.velocity += rb.rotation * Vector3.back * 5;
            //rb.velocity += rb.rotation * Vector3.left * 4;
            rb.velocity += rb.rotation * Vector3.up * 1.2f;

            rb.angularVelocity = rb.rotation * new Vector3(0, 20, 0);

            /*
            rb.velocity += Vector3.up * 4;
            rb.velocity += Vector3.back * 5;
            */

            rb.freezeRotation = false;
            cam.transform.parent = null;
        }
    }

    IEnumerator IDelayMovement(float delay, int direction)
    {
        //Debug.Log("Move in " + direction + " direction");

        yield return new WaitForSeconds(delay);

        if (direction == 0)
        {
            rb.velocity += new Vector3(0, 0, speeeeed);
        }

        if (direction == 1)
        {
            rb.velocity += new Vector3(-speeeeed, 0, 0);
        }

        if (direction == 2)
        {
            rb.velocity += new Vector3(0, 0, -speeeeed);
        }

        if (direction == 3)
        {
            rb.velocity += new Vector3(speeeeed, 0, 0);
        }
    }
}