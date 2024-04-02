using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Automatically toggles the attached gameobject to be attached based on the pausing state.
/// </summary>
public class ToggleOnPause : MonoBehaviour
{
    public bool valueOnPause = true;

    void Start()
    {
        // Adds callbacks to fire when the pause manager triggers a pause.
        PausingManager.onPauseCallback += OnPause;
        PausingManager.onUnpauseCallback += OnUnpause;

        //Sets the object to it's correct state as of this moment
        if (PausingManager.isPaused()) { OnPause(); }
        else { OnUnpause(); }
    }

    //Destructor to remove callbacks
    void OnDestroy()
    {
        PausingManager.onPauseCallback -= OnPause;
        PausingManager.onUnpauseCallback -= OnUnpause;
    }

    public void OnPause()
    {
        gameObject.SetActive(valueOnPause);
    }

    public void OnUnpause()
    {
        gameObject.SetActive(!valueOnPause);
    }


}
