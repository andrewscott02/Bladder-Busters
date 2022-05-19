using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class SaveInSession
{
    public static List<SaveData> playerScoresUnsorted = new List<SaveData>();

    public static void SaveScore(Score score)
    {
        SaveData currentSavedData = new SaveData();

        currentSavedData.player = score.playerName;
        currentSavedData.score = score.score;

        playerScoresUnsorted.Add(currentSavedData);

        foreach (var item in playerScoresUnsorted)
        {
            Debug.Log("Unsorted list = " + item.player + ": " + item.score);
        }

        SortData();
    }

    public static List<SaveData> playerScoresSorted = new List<SaveData>();

    public static void SortData()
    {
        playerScoresSorted = new List<SaveData>();

        int count = 0;

        List<SaveData> playerScoresUnsortedCopy = new List<SaveData>();

        foreach(var item in playerScoresUnsorted)
        {
            playerScoresUnsortedCopy.Add(item);
        }

        while (playerScoresUnsorted.Count != count)
        {
            SaveData bestSavedScore = new SaveData();
            foreach (var item in playerScoresUnsortedCopy)
            {
                if (bestSavedScore.score < item.score && playerScoresSorted.Contains(item) == false)
                {
                    bestSavedScore = item;
                }
            }

            playerScoresUnsortedCopy.Remove(bestSavedScore);
            playerScoresSorted.Add(bestSavedScore);
            count++;
        }
    }
}