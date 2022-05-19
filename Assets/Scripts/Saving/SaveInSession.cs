using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveInSession
{
    public static Dictionary<string, int> playerScoresUnsorted = new Dictionary<string, int>();

    public static void SaveScore(Score score)
    {
        playerScoresUnsorted.Add(score.playerName, score.score);

        foreach (var item in playerScoresUnsorted)
        {
            Debug.Log(item.Key + ": " + item.Value);
        }
    }
}
