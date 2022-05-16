using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrunkMeter : MonoBehaviour
{
    public float drunkScale = 0;
    public float drunkLossPerUpdate = 0;
    public GameObject drunkFX;

    JankMovement jankController;
    PissMeter pissMeter;
    public Slider drunkSlider;

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
        drunkSlider.value = drunkScale;

        if (drunkScale >= 0.4)
        {
            drunkFX.SetActive(true);
        }
        else
        {
            drunkFX.SetActive(false);
        }
    }
}