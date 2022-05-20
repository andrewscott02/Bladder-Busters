using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOverCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PissMeter pissMeter = other.GetComponent<PissMeter>();

            if (pissMeter != null)
            {
                pissMeter.IncreasePiss(1000000f);
            }
            else
            {
                pissMeter = other.GetComponentInParent<PissMeter>();

                if (pissMeter != null)
                {
                    pissMeter.IncreasePiss(1000000f);
                }
            }
        }
        
    }
}
