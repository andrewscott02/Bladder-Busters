using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterController : MonoBehaviour
{
    public Rigidbody rb;

    public int speeeeed = 1;
    public Vector2 inputDelay;

    public bool canMove = true;

    public void BustAMove(int direction)
    {
        if (canMove)
            StartCoroutine(IDelayMovement(Random.Range(inputDelay.x, inputDelay.y), direction));
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