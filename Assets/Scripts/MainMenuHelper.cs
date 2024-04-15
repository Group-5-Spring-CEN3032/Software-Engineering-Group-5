using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Helper component to provide scene loading and game quiting access as public functions.
/// </summary>
public class MainMenuHelper : MonoBehaviour
{
    public string sceneName;
    public void LoadScene() {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Debug.Log("Player quit the game.");
        Application.Quit();
    }
}
