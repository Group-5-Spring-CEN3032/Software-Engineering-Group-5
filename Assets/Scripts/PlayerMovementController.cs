using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    //References
    private Rigidbody body;

    //Accessible variables
    [SerializeField] private Transform cameraAxis;
    [SerializeField] private Vector2 mouseSensitivity = Vector2.one;
    [SerializeField] private float degreesPerSecondLookSpeed = 30f;
    [SerializeField] private float maxCameraAngle = 40f;
    [SerializeField] private float minCameraAngle = -40f;
    [SerializeField] private float cameraAngleOffset = 90f;
    [SerializeField] private float movementMult = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float timeBetweenJumps = 1f;
    [SerializeField] private float groundDetectionDistance = 0.25f;

    //Calculation variables, do not access
    private float timeSinceLastJump;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown("escape")) { PausingManager.TogglePause(); }
        if (PausingManager.isPaused()) return;

        // Camera movement
        float x = Input.GetAxis("Mouse X") * mouseSensitivity.x * degreesPerSecondLookSpeed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity.y * degreesPerSecondLookSpeed * Time.deltaTime;

        //Rotate player and camera
        transform.Rotate(Vector3.up * x); //Horizontal rotation
        cameraAxis.Rotate(Vector3.right * y); //Vertical rotation

        //extract and clamp camera vertical rotation
        Vector3 camRot = cameraAxis.localRotation.eulerAngles;
        camRot.x = Mathf.Clamp(camRot.x, minCameraAngle + cameraAngleOffset, maxCameraAngle + cameraAngleOffset);

        //Reassigning clamped camera rotation.
        Quaternion newCamQuat = new Quaternion();
        newCamQuat.eulerAngles = camRot;
        cameraAxis.localRotation = newCamQuat;


        //Movement Controls
        //Calculate MovementDir
        Vector3 movementDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (movementDir.magnitude > 1f) movementDir = Vector3.ClampMagnitude(movementDir, 1f);
        Vector3 rotatedMovementDir = (transform.right * movementDir.x) + (transform.forward * movementDir.z);

        //Horizontal movement
        body.AddForce(rotatedMovementDir * movementMult * Time.deltaTime, ForceMode.VelocityChange);

        //Jumping
        if (IsOnGround() && timeSinceLastJump > timeBetweenJumps && Input.GetAxisRaw("Jump") > 0.5f)
        {
            body.AddForce(Vector3.up * jumpForce * body.mass, ForceMode.Impulse);
            timeSinceLastJump = 0f;
        }
    }
    

    void FixedUpdate()
    {
        timeSinceLastJump += Time.fixedDeltaTime;
    }

    bool IsOnGround()
    {
        Vector3 origin = transform.position + (Vector3.down * 0.99f);
        return Physics.Raycast(new Ray(origin, Vector3.down), groundDetectionDistance);
    }

}
