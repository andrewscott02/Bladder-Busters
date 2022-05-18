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

    public Dictionary<string, int> localDict = new Dictionary<string, int>();

    private void Start()
    {
        Initialize();
    }

    public void PopulateNamesAndScores(PlayerData data)
    {
        // Guard clause to catch missing data error
        if (data != null)
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

            localDict = new Dictionary<string, int>(data.SortScoresDictionary());
            Debug.Log(localDict);

            // load names
            for (int i = 0; i < names.Count; i++)
            {
                names[i].text = localDict.Keys.First<string>();
            }

            // Load scores
            for (int i = 0; i < scores.Count; i++)
            {
                scores[i].text = localDict.Values.First<int>().ToString();
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
        PopulateNamesAndScores(SaveSystem.LoadScores());
    }
}
