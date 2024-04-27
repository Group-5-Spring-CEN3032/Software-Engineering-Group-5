using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    /// <summary>
    /// variables that are need
    /// </summary>
    private BarUI bar;
    private Stats stats;
    [SerializeField]
    public bool healthbarVisibility;
    

    // Start is called before the first frame update
    void Start()
    {
        Transform canvasTransform;
        Transform barTransform;
        canvasTransform = transform.Find("Canvas");
        barTransform = canvasTransform.Find("Healthbar");
        bar = barTransform.GetComponent<BarUI>();
        stats = GetComponent<Stats>();
        bar.SetMaxStat(stats.MaxHealth);
        bar.gameObject.SetActive(healthbarVisibility);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if(healthbarVisibility == true)
        {
            stats.SetStat(damage, "health", bar);

            if(stats.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
