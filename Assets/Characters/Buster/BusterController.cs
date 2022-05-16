using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterController : MonoBehaviour
{
    public Rigidbody rb;

    public int speeeeed = 1;
    public Vector2 inputDelay;

    public bool canMove = true;
    public Camera cam;

    public void BustAMove(int direction)
    {
        if (canMove)
            StartCoroutine(IDelayMovement(Random.Range(inputDelay.x, inputDelay.y), direction));
    }

    private void FixedUpdate()
    {
        if (canMove == false)
        {
            rb.velocity += rb.rotation * Vector3.back * 5;
            rb.velocity += rb.rotation * Vector3.left * 4;
            rb.velocity += Vector3.up * 1.2f;

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
        Debug.Log("Move in " + direction + " direction");

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