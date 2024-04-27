using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField]
    private Stats stats;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform firePosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float targetTime;
    private float time;
    public bool enemyAttcking;

    // Start is called before the first frame update
    void Start()
    {
        time = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            if (Input.GetMouseButtonDown(1) && this.transform.parent.parent.gameObject.tag == "Player")
            {
                LaunchProjectile();
                targetTime = time;
            }
            else if(enemyAttcking == true)
            {
                LaunchProjectile();
                targetTime = time;
            }
        }
    }

    void LaunchProjectile()
    {
        var bullet = Instantiate(projectile, firePosition.position, firePosition.rotation);
        bullet.GetComponent<Projectile>().SetDamage(stats.AttackPower);
        bullet.GetComponent<Rigidbody>().velocity = firePosition.forward * speed;
    }
}
