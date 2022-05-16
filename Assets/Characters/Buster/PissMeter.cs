using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PissMeter : MonoBehaviour
{
    public float pissScale = 0;
    public float pissIncreasePerUpdate = 0;
    BusterController busterController;

    public GameObject pissFX;
    public Object pissFXGameOver;

    public Transform penisTransform;
    public Slider pissSlider;

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
            pissFX.SetActive(false);
            PissYourself();
        }
        else if (pissScale >= 0.8)
        {
            pissFX.SetActive(true);
        }
        else
        {
            pissFX.SetActive(false);
        }
    }

    bool alreadyLost = false;

    void PissYourself()
    {
        if (alreadyLost == false)
        {
            alreadyLost = true;
            busterController.canMove = false;

            if (pissFXGameOver != null)
            {
                Instantiate(pissFXGameOver, penisTransform);
            }
        }
    }

    public void TakeThePiss(float pissDecrease)
    {
        pissScale -= pissDecrease;
    }

    private void FixedUpdate()
    {
        IncreasePiss(pissIncreasePerUpdate);
        pissSlider.value = pissScale;
    }
}