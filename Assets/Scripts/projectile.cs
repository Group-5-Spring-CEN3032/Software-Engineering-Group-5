using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;
    private float damage;

    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<NPC>(out NPC NPCComponent))
        {
            NPCComponent.TakeDamage(damage);
        }

        if(collision.gameObject.TryGetComponent<Player>(out Player PlayerComponent))
        {
            PlayerComponent.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
