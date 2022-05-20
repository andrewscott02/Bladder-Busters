using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Gets the players name at the end of the game and writes it to the score script
/// 
/// written by @MattRobertsCGD
/// </summary>
public class GetName : MonoBehaviour
{
    public TMP_InputField nameField;
    public string SendNameForScore()
    {
        Debug.Log("playerName is " + nameField.text);
        return nameField.text;
    }
}
