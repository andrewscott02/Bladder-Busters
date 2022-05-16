using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissMeter : MonoBehaviour
{
    public float pissScale = 0;
    public float pissIncreasePerUpdate = 0;
    BusterController busterController;

    private void Start()
    {
        busterController = GetComponent<BusterController>();
    }

    public void IncreasePiss(float pissIncrease)
    {
        pissScale += pissIncrease;

        if (pissScale >= 1)
        {
            //Lose Game
            busterController.canMove = false;
        }
    }

    public void TakeThePiss(float pissDecrease)
    {
        pissScale -= pissDecrease;
    }

    private void FixedUpdate()
    {
        IncreasePiss(pissIncreasePerUpdate);
    }
}