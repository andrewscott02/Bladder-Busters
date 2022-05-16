using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankMovement : MonoBehaviour
{
    public Dictionary<KeyCode, int> inputDirections;

    public BusterController busterController;
    public ControlsUI controlUI;

    DrunkMeter drunkMeter;

    private void Start()
    {
        drunkMeter = GetComponent<DrunkMeter>();

        inputDirections = new Dictionary<KeyCode, int>();

        inputDirections.Add(KeyCode.W, 0);
        inputDirections.Add(KeyCode.A, 1);
        inputDirections.Add(KeyCode.S, 2);
        inputDirections.Add(KeyCode.D, 3);

        controlUI.ConfigureControls(inputDirections);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W pressed: move " + DetermineDirection(KeyCode.W));
            busterController.BustAMove(DetermineDirection(KeyCode.W));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A pressed: move " + DetermineDirection(KeyCode.A));
            busterController.BustAMove(DetermineDirection(KeyCode.A));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("S pressed: move " + DetermineDirection(KeyCode.S));
            busterController.BustAMove(DetermineDirection(KeyCode.S));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("D pressed: move " + DetermineDirection(KeyCode.D));
            busterController.BustAMove(DetermineDirection(KeyCode.D));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("randomise");
            drunkMeter.Drink(0.1f, 0.1f); ;
        }
    }

    int DetermineDirection(KeyCode keyCode)
    {
        return inputDirections[keyCode];
    }

    public void RandomiseInputs()
    {
        List<int> newInputDirections = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            int testDirection = Random.Range(0, 4);

            while (newInputDirections.Contains(testDirection))
            {
                testDirection = Random.Range(0, 4);
            }

            newInputDirections.Add(testDirection);
        }

        inputDirections[KeyCode.W] = newInputDirections[0];
        inputDirections[KeyCode.A] = newInputDirections[1];
        inputDirections[KeyCode.S] = newInputDirections[2];
        inputDirections[KeyCode.D] = newInputDirections[3];

        controlUI.ConfigureControls(inputDirections);
    }
}