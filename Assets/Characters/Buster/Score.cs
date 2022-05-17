using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;

    public GameObject start;

    public Text scoreText;

    DrunkMeter drunkMeter;
    public float drunkMultiplier;

    private void Start()
    {
        drunkMeter = GetComponent<DrunkMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drunkMeter.GetJankMovement().busterController.canMove)
        {
            float drunkScale = drunkMeter.drunkScale * drunkMultiplier;
            score = (int)(Vector3.Distance(transform.position, start.transform.position) * (drunkScale > 1 ? drunkScale : 1));
            scoreText.text = score.ToString();
        }
    }

    public void EndGame()
    {
        Debug.Log("My Score is " + score);

        //Save Player Score Here
    }
}