using System;
using System.Collections.Generic;

public class PlayerData
{
    public Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();
    string newPlayer;
    public PlayerData(Score score)
    {

        // Iterate through the scores array
        for (int i = 0; i < scoreDictionary.Count; i++)
        {
            // Sort the array before editing it
            SortScoresDictionary();
            // Make sure the current position in the array isn't populated
            if (!scoreDictionary.ContainsKey(newPlayer))
            {
                scoreDictionary.Add(newPlayer, score.score);
                //scores[i] = score.score;
            }
            // If it is, ammend the players last score
            else
            {
                scoreDictionary[newPlayer] = score.score;
            }
        }
    }

    /// <summary>
    /// Sorts the score dictionary
    /// </summary>
    public void SortScoresDictionary()
    {

    }
}
