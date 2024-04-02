using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    /// <summary>
    /// variables that are need
    /// </summary>
    [SerializeField]
    private BarUI bar;
    [SerializeField]
    private Stats stats;
    [SerializeField]
    bool visibility;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        bar.SetMaxStat(stats.MaxHealth);
        bar.gameObject.SetActive(visibility);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if(visibility == true)
        {
            stats.SetStat(damage, "health", bar);

            if(stats.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
