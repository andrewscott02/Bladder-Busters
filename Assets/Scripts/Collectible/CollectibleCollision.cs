using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    public Collectible collectible;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && collectible != null)
        {
            if (collectible.collectFX != null)
            {
                //Instantiate FX
                Instantiate(collectible.collectFX);
            }

            DrunkMeter drunkMeter = other.GetComponent<DrunkMeter>();
            PissMeter pissMeter = other.GetComponent<PissMeter>();

            if (drunkMeter != null && pissMeter)
            {
                //Adjust Player Stats
                collectible.AdjustPlayerStats(drunkMeter, pissMeter);
            }
        }

        //Destroy this collectible
        Destroy(this.gameObject);
    }
}