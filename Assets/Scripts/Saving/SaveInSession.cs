using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class SaveInSession : MonoBehaviour
{
    public SaveInSession()
    {

    }

    public static SaveInSession instance;

    private void Start()
    {
        if (instance = null)
        {
            Destroy(this);
        }
        else
        {
            SaveInSession.instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static List<SaveData> playerScoresUnsorted = new List<SaveData>();

    public static void SaveScore(Score score)
    {
        SaveData currentSavedData = new SaveData();

        currentSavedData.player = score.playerName;
        currentSavedData.score = score.score;

        playerScoresUnsorted.Add(currentSavedData);

        foreach (var item in playerScoresUnsorted)
        {
            Debug.Log(item.player + ": " + item.score);
        }

        SortData();
    }

    public static List<SaveData> playerScoresSorted = new List<SaveData>();

    public static void SortData()
    {
        playerScoresSorted = new List<SaveData>();

        int count = 0;

        while (playerScoresUnsorted.Count != count)
        {
            SaveData bestSavedScore = new SaveData();
            foreach (var item in playerScoresUnsorted)
            {
                if (bestSavedScore.score < item.score)
                {
                    bestSavedScore.player = item.player;
                    bestSavedScore.score = item.score;
                }
            }

            playerScoresSorted.Add(bestSavedScore);
            count++;
        }
    }
}

public class SaveData
{
    public string player = " ";
    public int score = 0;
}
