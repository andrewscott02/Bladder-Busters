using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        
        // Iterate through the scores array
        for (int i = 0; i < scoreDictionaryUnsorted.Count; i++)
        {
            string pName = SaveInSession.playerName;
            int pScore = SaveInSession.score; // player score? more like pInt, lets get shitfaced.
            
            scoreDictionaryUnsorted.Add(pName, pScore);
            
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
