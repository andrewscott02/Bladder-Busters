using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace BladderBlaster.UI
{
    /// <summary>
    /// Used for doing basic functions in the main menu such as loading and controlling panels
    /// 
    /// written by @MattRobertsCGD
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        public GameObject[] panels = new GameObject[4];

        private void Start()
        {
            //Disable all panels.
            for (int i = 0; i < panels.Length; i++)
            {
                if (panels[i] == null)
                    return;
                
                panels[i].SetActive(false);
            }
        }

        #region MENU FUNCTIONS

        /// <summary>
        /// Quits the game.
        /// </summary>
        public void QuitGame()
        {
            Debug.Log("Quit called, closing game");
            Application.Quit();

#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
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

        public void ClearData()
        {
            Debug.LogWarning("Cleared player data");
            SaveSystem.ClearData();
        }

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }
        #endregion
    }
}
