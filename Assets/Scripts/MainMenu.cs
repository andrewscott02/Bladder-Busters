using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BladderBlaster.UI
{
    /// <summary>
    /// Used for doing basic functions in the main menu such as loading and controlling panels
    /// 
    /// written by @MattRobertsCGD
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetAssignables();
        }

        #region LEVEL FUNCTIONS
        public void QuitGame()
        {
            Debug.Log("Quit called, closing game");
            Application.Quit();
        }

        public void LoadLevel(int sceneNumber)
        {
            Debug.Log("Loading scene number " + sceneNumber);
            SceneManager.LoadScene(sceneNumber);
        }
        #endregion

        #region UTILS
        private void GetAssignables()
        {

        }
        #endregion
    }
}