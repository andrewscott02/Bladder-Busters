using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PlayerData
{
    public Dictionary<string, int> scoreDictionaryUnsorted = new Dictionary<string, int>();
    public PlayerData(Score score)
    {
        // Iterate through the scores array
        for (int i = 0; i < scoreDictionaryUnsorted.Count; i++)
        {
            string pName = score.playerName;
            int pScore = score.score; // player score? more like pInt, lets get shitfaced.

            // Sort the array before editing it
            SortScoresDictionary();
            // Make sure the current position in the array isn't populated
            if (!scoreDictionaryUnsorted.ContainsKey(pName))
            {
                scoreDictionaryUnsorted.Add(pName, pScore);
            }
            // If it is, ammend the players last score
            else
            {
                scoreDictionaryUnsorted[pName] = pScore;
            }
        }
    }

    /// <summary>
    /// Sorts the score dictionary
    /// </summary>
    public Dictionary<string, int> SortScoresDictionary()
    {
        // No idea if this works, pain.
        var sortedScores = from entry in scoreDictionaryUnsorted orderby entry.Value ascending select entry;
        Dictionary<string, int> sortedScoresDict = new Dictionary<string, int>();
        sortedScoresDict = sortedScores as Dictionary<string, int>;
        return sortedScoresDict;
    }
}
