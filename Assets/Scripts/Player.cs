using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class Player : MonoBehaviour
{
    /// <summary>
    /// variables that are need
    /// </summary>
    [SerializeField]
    private BarUI bar, bar2, bar3;
    private Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();

        bar.SetMaxStat(stats.MaxHealth);
        bar2.SetMaxStat(stats.MaxMana);
        bar3.SetMaxStat(stats.MaxStamina);
    }

    /// <summary>
    /// Update is called once per frame
    /// test to make sure the different bars work.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            float num = 20f;
            stats.SetStat(num, "mana", bar2);
        }

        if (Input.GetKeyDown("h"))
        {
            float num = 20f;
            stats.SetStat(num, "stamina", bar3);
        }
    }

    public void TakeDamage(float damage)
    {
        stats.SetStat(damage, "health", bar);

        if (stats.Health <= 0)
        {
            StartCoroutine(LoadScenesWithDelay("Death", 1f));
        }
    }

    private IEnumerator LoadScenesWithDelay(string firstSceneName, float firstSceneDelay)
    {
        SceneManager.LoadScene(firstSceneName);
        yield return new WaitForSeconds(firstSceneDelay);
    }
}