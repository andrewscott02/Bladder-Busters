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

    public void Drink(float drinkIncrease)
    {
        drunkScale = Mathf.Clamp(drunkScale + drinkIncrease, 0, 1);

        jankController.RandomiseInputs();
    }

    public void SoberUp(float drinkDecrease, bool resetControls)
    {
        drunkScale = Mathf.Clamp(drunkScale - drinkDecrease, 0, 1);

        if (resetControls)
            jankController.StandardControls();
    }

    private void FixedUpdate()
    {
        if (jankController.busterController.canMove)
        {
            SoberUp(drunkLossPerUpdate, false);
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

    public JankMovement GetJankMovement()
    {
        return jankController;
    }
}