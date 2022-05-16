using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkMeter : MonoBehaviour
{
    public float drunkScale = 0;
    public float drunkLossPerUpdate = 0;

    JankMovement jankController;
    PissMeter pissMeter;

    private void Start()
    {
        jankController = GetComponent<JankMovement>();
        pissMeter = GetComponent<PissMeter>();
    }

    public void Drink(float drinkIncrease, float pissIncrease)
    {
        drunkScale += drinkIncrease;

        pissMeter.IncreasePiss(pissIncrease);
        jankController.RandomiseInputs();
    }

    public void SoberUp(float drinkDecrease)
    {
        drunkScale = Mathf.Clamp(drunkScale - drinkDecrease, 0, 1);
    }

    private void FixedUpdate()
    {
        SoberUp(drunkLossPerUpdate);
    }
}