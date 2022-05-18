using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMessage : MonoBehaviour
{
    public GameObject objectToEnable;
    public Text messageText;

    public void ShowMessageDelay(string message, float delay)
    {
        StartCoroutine(IShowMessage(message, delay));
    }

    IEnumerator IShowMessage(string message, float delay)
    {
        yield return new WaitForSeconds(delay);

        ShowMessage(message);
    }

    public void ShowMessage(string message)
    {
        objectToEnable.SetActive(true);
        messageText.text = message;
    }

    /// <summary>
    /// Loads a level
    /// </summary>
    /// <param name="sceneNumber">The build index of the level you want to load</param>
    public void LoadLevel(int sceneNumber)
    {
        Debug.Log("Loading scene number " + sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }
}
