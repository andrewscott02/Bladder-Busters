using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    bool playing = true;
    public string playerName;
    public int score;

    public GameObject start;

    public EndGameMessage endGameMessage;
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
        if (playing)
        {
            float drunkScale = drunkMeter.drunkScale * drunkMultiplier;
            score = (int)(Vector3.Distance(transform.position, start.transform.position) * (drunkScale > 1 ? drunkScale : 1));
            scoreText.text = score.ToString();
        }
    }

    public void EndGame(string message)
    {
        Debug.Log("My Score is " + score);
        Debug.Log("Message is " + message);
        scoreText.text = score.ToString();
        playing = false;

        //Save Player Score Here
        SaveSystem.SaveScore(this);
        endGameMessage.ShowMessageDelay(message, 2f);
    }
}