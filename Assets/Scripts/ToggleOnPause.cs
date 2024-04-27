using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Automatically toggles the attached gameobject to be attached based on the pausing state.
/// </summary>
public class ToggleOnPause : MonoBehaviour
{
    [SerializeField] private bool valueOnPause = true;

    
    void Start()
    {
        // Adds callbacks to fire when the pause manager triggers a pause.
        PausingManager.onPauseCallback += OnPause;
        PausingManager.onUnpauseCallback += OnUnpause;

        SetValueOnPause(valueOnPause);
    }

    //Destructor to remove callbacks
    void OnDestroy()
    {
        PausingManager.onPauseCallback -= OnPause;
        PausingManager.onUnpauseCallback -= OnUnpause;
    }

    private void OnPause()
    {
        gameObject.SetActive(valueOnPause);
    }

    private void OnUnpause()
    {
        gameObject.SetActive(!valueOnPause);
    }

    public void SetValueOnPause(bool newValue)
    {
        // Sets the object to it's correct state as of this moment
        if (PausingManager.isPaused()) { OnPause(); }
        else { OnUnpause(); }
    }
    public bool GetValueOnPause() { return valueOnPause; }
}
