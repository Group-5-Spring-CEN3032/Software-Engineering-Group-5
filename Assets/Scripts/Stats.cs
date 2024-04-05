using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    /// <summary>
    /// variables that are need
    /// set these variables in the unity engine
    /// </summary>
    private float health, maxHealth, mana, maxMana, stamina, maxStamina, attackPower;

    /// <summary>
    /// Getter and setter for health
    /// </summary>
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    /// <summary>
    /// Getter and setter for max health
    /// </summary>
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    /// <summary>
    /// Getter and setter for mana
    /// </summary>
    public float Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    /// <summary>
    /// Getter and setter for max mana
    /// </summary>
    public float MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    /// <summary>
    /// Getter and setter for stamina
    /// </summary>
    public float Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    /// <summary>
    /// Getter and setter for max stamina
    /// </summary>
    public float MaxStamina
    {
        get { return maxStamina; }
        set { maxStamina = value; }
    }

    /// <summary>
    /// Getter and setter for attack power
    /// </summary>

    public float AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    /// <summary>
    /// This is were the type of stat and the stat change is taken in an calculte the new stat total and sends it to the right bar to get updated.
    /// </summary>
    /// <param name="statChange">The amount the stat will change</param>
    /// <param name="stat">The stat you are going to change</param>
    public void SetStat(float statChange, string stat, BarUI bar)
    {
        if(string.Compare(stat,"health") == 0)
        {
          Health = Health - statChange;
          Health = Mathf.Clamp(Health, 0, MaxHealth);
          bar.SetStat(Health);
        }
        else if(string.Compare(stat,"mana") == 0)
        {
            Mana = Mana - statChange;
            Mana = Mathf.Clamp(Mana, 0, MaxMana);
            bar.SetStat(Mana);
        }
        else if(string.Compare(stat,"stamina") == 0)
        {
            Stamina = Stamina - statChange;
            Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
            bar.SetStat(Stamina);
        }
    }
}