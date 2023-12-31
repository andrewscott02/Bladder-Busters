using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

/// <summary>
/// Simple script that can go on any gameobject to call a load of the save data
/// 
/// written by @MattRobertsCGD
/// </summary>
public class HighscoreLoader : MonoBehaviour
{
    public List<TMP_Text> names = new List<TMP_Text>();
    public List<TMP_Text> scores = new List<TMP_Text>();

    public List<SaveData> localDict = new List<SaveData>();

    private void Start()
    {
        Initialize();
    }

    public void PopulateNamesAndScores()
    {
        // Guard clause to catch missing data error
        if (SaveInSession.playerScoresSorted.Count > 0)
        {
            // Clear any text from names and scores
            for (int i = 0; i < names.Count; i++)
            {
                names[i].text = null;
            }
            for (int i = 0; i < scores.Count; i++)
            {
                scores[i].text = null;
            }

            localDict = new List<SaveData>(SaveInSession.playerScoresSorted);

            foreach(var item in localDict)
            {
                Debug.Log(item.player);
                Debug.Log(item.score);
            }

            // load names
            for (int i = 0; i < SaveInSession.playerScoresSorted.Count; i++)
            {
                names[i].text = SaveInSession.playerScoresSorted[i].player;
            }

            // Load scores
            for (int i = 0; i < SaveInSession.playerScoresSorted.Count; i++)
            {
                scores[i].text = SaveInSession.playerScoresSorted[i].score.ToString();
            }
        }
        else
        {
            names[0].text = "NO";
            scores[0].text = "SCORES";
            // Clear any text from names and scores
            for (int i = 1; i < names.Count; i++)
            {
                names[i].text = null;
            }
            for (int i = 1; i < scores.Count; i++)
            {
                scores[i].text = null;
            }
        }
    }

    public void Initialize()
    {
        PopulateNamesAndScores();
    }
}
