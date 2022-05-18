using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Class that handles the saving and loading of data using system IO and a binary formatter.
/// 
/// written by @MattRobertsCGD
/// </summary>
public static class SaveSystem
{
    /// <summary>
    /// Converts the scores to binary and then saves them. Uses the playerData contructor setup in PlayerData.cs
    /// </summary>
    /// <param name="score"></param>
    public static void SaveScore(Score score)
    {
        // Create new formatter.
        BinaryFormatter formatter = new BinaryFormatter();
        // Setup our file path, using unitys persistent data path func.
        string path = Application.persistentDataPath + "/player.scores";
        // Create a new filestream to make our file.
        FileStream stream = new FileStream(path, FileMode.Create);

        // Pass in the the data that we need to save.
        PlayerData data = new PlayerData(score);

        // Save the data by serializing it.
        formatter.Serialize(stream, data);
        // Close filestream when done.
        stream.Close();
    }


    /// <summary>
    /// Loads player data from binary and converts it back to a useable format.
    /// </summary>
    /// <returns></returns>
    public static PlayerData LoadScores()
    {
        // Setup our file path, using unitys persistent data path func.
        string path = Application.persistentDataPath + "/player.scores";
        
        // Check to see if the file exists, if not, we throw an error.
        if (File.Exists(path))
        {
            // Create new formatter.
            BinaryFormatter formatter = new BinaryFormatter();
            // Create a new filestream to make our file.
            FileStream stream = new FileStream(path, FileMode.Open);
            // Deserialize the data, meaning it's in a useable format. Cast it to PlayerData that we can use
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            // Close the filestream when done.
            stream.Close();

            // Return our data.
            return data; 
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    /// <summary>
    /// Clears data if the file exists and logs it to the console.
    /// </summary>
    public static void ClearData()
    {
        // Setup our file path, using unitys persistent data path func.
        string path = Application.persistentDataPath + "/player.scores";
        if (File.Exists(path))
        {
            Debug.Log("CLEARED PLAYER DATA");
            File.Delete(path);
        }
        else
        {
            Debug.LogWarning("SaveSystem: No data found.. Continuing");
        }
    }
}
