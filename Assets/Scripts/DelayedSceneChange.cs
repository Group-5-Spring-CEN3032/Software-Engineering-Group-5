using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DelayedSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // The name of the scene to load
    [SerializeField] private float delayInSeconds; // The delay before changing the scene

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(sceneToLoad, delayInSeconds));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
