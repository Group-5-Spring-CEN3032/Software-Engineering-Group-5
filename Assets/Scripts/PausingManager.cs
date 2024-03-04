using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PausingManager
{
    public delegate void OnPause();
    public static OnPause onPauseCallback;
    public delegate void OnUnpause();
    public static OnUnpause onUnpauseCallback;


    public static bool isPaused() { return Time.timeScale == 0f; }

    public static void Pause()
    {
        Time.timeScale = 0f;
        if (onPauseCallback != null) onPauseCallback();
    }

    public static void Unpause()
    {
        Time.timeScale = 1f;
        onUnpauseCallback();
    }

    public static void TogglePause()
    {
        if (isPaused()) { Unpause(); }
        else { Pause(); }
    }
}
