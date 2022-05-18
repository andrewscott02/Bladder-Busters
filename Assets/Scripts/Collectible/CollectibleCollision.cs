using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    public Collectible collectible;

    public bool destroyObject;
    bool alreadyCollected = false;
    public GameObject objectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyCollected == false)
        {
            if (other.CompareTag("Player") && collectible != null)
            {
                if (collectible.collectFX != null)
                {
                    //Instantiate FX
                    Instantiate(collectible.collectFX, this.gameObject.transform.position, this.gameObject.transform.rotation);
                }

                DrunkMeter drunkMeter = other.GetComponent<DrunkMeter>();
                PissMeter pissMeter = other.GetComponent<PissMeter>();

                if (drunkMeter != null && pissMeter)
                {
                    //Adjust Player Stats
                    collectible.AdjustPlayerStats(drunkMeter, pissMeter);
                }

                if (destroyObject)
                {
                    //Destroy this collectible
                    Destroy(this.gameObject);
                }
                else
                {
                    alreadyCollected = true;

                    if (objectToDisable != null)
                    {
                        objectToDisable.SetActive(false);
                    }
                }
            }
        }
    }
}