using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Simple splash screen to work around Unity's quirk of not allowing lighting or some packages on the first loaded scene.
/// </summary>
public class Splash : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private string nextScene = "SampleScene";
    void Start()
    {
       StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextScene);
    }
}
