using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PauseManagerStateCheckTest()
    {
        // Use the Assert class to test conditions
        PausingManager.Pause();
        Assert.True(PausingManager.isPaused());
        Assert.AreEqual(Time.timeScale, 0f);
        PausingManager.Unpause();
        Assert.False(PausingManager.isPaused());
        Assert.AreEqual(Time.timeScale, 1f);
    }

    /*[UnityTest]
    public IEnumerator PauseTestWithEnumeratorPasses()
    {
        GameObject go = new GameObject();
        ToggleOnPause t = go.AddComponent<ToggleOnPause>();
        t.SetValueOnPause(true);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame
        // Give the component a frame to run it's setup tests;


        PausingManager.Unpause();
        yield return null;
        Assert.False(go.activeSelf);    //Verify the gameobject is disabled
        PausingManager.Pause();
        yield return null;
        Assert.True(go.activeSelf); //verify the gameobject is enabled.
        PausingManager.Unpause();
        yield return null;
        Assert.False(go.activeSelf);
    }*/
}
