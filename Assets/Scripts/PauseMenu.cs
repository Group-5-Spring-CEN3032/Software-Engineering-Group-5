using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ToggleOnPause))]
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        PausingManager.Unpause();
    }
}
