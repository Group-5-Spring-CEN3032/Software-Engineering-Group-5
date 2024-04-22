using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class PersistentStats : PersistentClass<PersistentStatsData>
{
    private Stats s;

    void Awake()
    {
        s = GetComponent<Stats>();   
    }

    void OnEnable()
    {
        PersistentStatsData d = Deserialize();
        if (d != default(PersistentStatsData)) d.Apply(s);
    }

    void OnDisable()
    {
        Serialize(new PersistentStatsData(s));
    }
}

public class PersistentStatsData
{
    public float health;
    public float maxHealth;
    public float mana;
    public float maxMana;
    public float stamina;
    public float maxStamina;

    public PersistentStatsData(Stats s)
    {
        this.health = s.Health;
        this.maxHealth = s.MaxHealth;
        this.mana = s.Mana;
        this.maxHealth = s.MaxHealth;
        this.stamina = s.Stamina;
        this.maxStamina = s.Stamina;
    }

    public void Apply(Stats s)
    {
        s.Health = this.health;
        s.MaxHealth = this.maxHealth;
        s.Mana = this.mana;
        s.MaxMana = this.maxMana;
        s.Stamina = this.stamina;
        s.MaxStamina = this.maxStamina;
    }
}
