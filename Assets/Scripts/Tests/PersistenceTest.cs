using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PersistenceTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PersistenceUUIDTest()
    {
        // Use the Assert class to test conditions
        GameObject go = new GameObject();
        PersistentTransform pt = go.AddComponent<PersistentTransform>();
        Assert.True(pt.GetUUID() != null);
        Assert.True(pt.GetUUID() != "");
        GameObject.Destroy(go);
    }

}
