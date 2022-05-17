using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectible", order = 0)]
public class Collectible : ScriptableObject
{
    public Object collectFX;

    public float drunkValue;
    public float pissValue;

    public void AdjustPlayerStats(DrunkMeter drunkMeter, PissMeter pissMeter)
    {
        if (drunkValue > 0)
        {
            drunkMeter.Drink(drunkValue);
        }
        else if (drunkValue < 0)
        {
            drunkMeter.SoberUp(-drunkValue, true);
        }

        if (pissValue > 0)
        {
            pissMeter.IncreasePiss(pissValue);
        }
        if (pissValue < 0)
        {
            pissMeter.TakeThePiss(-pissValue);
        }
    }
}