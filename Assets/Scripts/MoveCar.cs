using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public GameObject point1, point2;
    

    bool state;
    float currentTime = 0;
    public float journeyInterval = 0.1f;

    private void Start()
    {
        StartCoroutine(CarMovement());
        RecalculateSpeed();
    }

    public void RecalculateSpeed()
    {
        journeyInterval *= 10;
#if UNITY_EDITOR
        journeyInterval /= 10;
#endif
    }

    private void Update() {
        MoveBetween();
        currentTime += journeyInterval;
    }

    void MoveBetween()
    {
        //float fracComplete = (Time.time - startTime) / journeyTime;

        if (state)
        {
            transform.position = Vector3.Lerp(point1.transform.position, point2.transform.position, currentTime);
            //Debug.Log("moving from 1 - 2");
        }
        else
        {
            transform.position = Vector3.Lerp(point2.transform.position, point1.transform.position, currentTime);
            //Debug.Log("moving from 2 - 1");
        }
    }

    IEnumerator CarMovement()
    {
        state = true;
        currentTime = 0;
        yield return new WaitForSeconds(5);
        state = false;
        currentTime = 0;
        yield return new WaitForSeconds(5);
        StartCoroutine(CarMovement());
    }
}
