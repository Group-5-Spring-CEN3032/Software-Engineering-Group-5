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
        Assert.Equals(Time.timeScale, 0f);
        PausingManager.Unpause();
        Assert.False(PausingManager.isPaused());
        Assert.Equals(Time.timeScale, 1f);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
   /* [UnityTest]
    public IEnumerator PauseTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
