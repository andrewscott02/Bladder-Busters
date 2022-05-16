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
        #region MENU FUNCTIONS

        /// <summary>
        /// Quits the game.
        /// </summary>
        public void QuitGame()
        {
            Debug.Log("Quit called, closing game");
            Application.Quit();
        }

        /// <summary>
        /// Loads a level
        /// </summary>
        /// <param name="sceneNumber"></param>
        public void LoadLevel(int sceneNumber)
        {
            Debug.Log("Loading scene number " + sceneNumber);
            SceneManager.LoadScene(sceneNumber);
        }
        #endregion

        #region UTILS
        #endregion
    }
}