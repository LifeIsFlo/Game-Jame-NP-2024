using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Stuff")]
    [SerializeField] private bool allowedToMove = true;
    [SerializeField]
    float moveSpeed = 5;
    [Header("Jumping")]
    public float JumpStrength = 30;
    public float jumpCooldown = 0f;
    [Header("Camera")]
    public float rotationSpeed = 5;
    [Header("Physics")]
    private float vertical;
    private float horizontal;
    private Rigidbody body;
    public bool canJump = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
        rotationSpeed = gameObject.GetComponentInChildren<CameraMovement>().rotationSpeed;
        Cursor.visible = false;
    }
    void Update()
    {
        if (gameObject.GetComponentInChildren<CameraMovement>().cameraMoves == true)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);
        }
    }
    private void FixedUpdate()
    {
        if (allowedToMove)
        {
            vertical = Input.GetAxis("Forwards");
            horizontal = Input.GetAxis("Sideways");
            Vector3 velocity = (transform.forward * vertical) * moveSpeed * Time.fixedDeltaTime;
            float newSpeed = moveSpeed;
            float newJump = JumpStrength;
            if (newSpeed > 0)
            {
                if (Input.GetAxis("Forwards") != 0 && Input.GetAxis("Sideways") == 0)
                {
                    velocity = (transform.forward * vertical) * (newSpeed * 100) * Time.fixedDeltaTime;
                }
                if (Input.GetAxis("Sideways") != 0 && Input.GetAxis("Forwards") == 0)
                {
                    velocity = (transform.right * horizontal) * (newSpeed * 100) * Time.fixedDeltaTime;
                }
                if (Input.GetAxis("Sideways") != 0 && Input.GetAxis("Forwards") != 0)
                {
                    velocity = (transform.right * horizontal + transform.forward * vertical) * (newSpeed * 100) * Time.fixedDeltaTime;
                }
                if (Input.GetAxis("Jump") != 0 && jumpCooldown == 0 && canJump == true)
                {
                    body.AddForce(transform.up * (newJump * 1000));
                    jumpCooldown = 10000;
                }
            }
            velocity.y = body.velocity.y;
            body.velocity = velocity;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumpCooldown = 0;
        body.angularVelocity = new Vector3(0f, body.velocity.y, body.velocity.z);
    }
}

