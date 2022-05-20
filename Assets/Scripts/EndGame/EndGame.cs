using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public int scoreBonus = 200;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Score score = other.GetComponent<Score>();
            BusterController controller = other.GetComponent<BusterController>();

            if (controller.canMove)
            {
                if (controller != null)
                {
                    controller.canMove = false;
                }

                if (score != null)
                {
                    //Adjust Player Stats
                    score.score += scoreBonus;
                    score.EndGame("You arrived home");
                }

                //Destroy this collectible
                Destroy(this.gameObject);
            }
        }
    }
}
