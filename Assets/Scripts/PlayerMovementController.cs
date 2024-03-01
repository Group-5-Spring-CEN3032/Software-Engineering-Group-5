using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //Accessible variables
    [SerializeField] private Transform cameraAxis;
    [SerializeField] private Vector2 mouseSensitivity = Vector2.one;
    [SerializeField] private float degreesPerSecondLookSpeed = 30f;
    [SerializeField] private float maxAngle = 75f;

    //Calculation variables
    [SerializeField] private float yAngle = 0f;

    void Start()
    {
        //yAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * mouseSensitivity.x * degreesPerSecondLookSpeed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity.y * degreesPerSecondLookSpeed * Time.deltaTime * -1f;

        yAngle += y;
        if (yAngle > maxAngle)
        {
            y = 0;
            yAngle = maxAngle;
        }
        if (yAngle < -maxAngle)
        {
            y = 0;
            yAngle = -maxAngle;
        }

        transform.Rotate(Vector3.up * x);
        cameraAxis.Rotate(Vector3.right * y);
    }
}
