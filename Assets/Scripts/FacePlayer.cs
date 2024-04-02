using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform playerCamera;

    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera != null)
        {
            Vector3 directionToPlayer = playerCamera.position - transform.position;

            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
