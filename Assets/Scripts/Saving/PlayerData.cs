using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int[] scores = new int[10];
    public string[] names = new string[10];

    public PlayerData(Score score)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] != 0)
            {
                scores[i] = score.score;
            }
        }
    }
}
