using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Stuff")]
    [SerializeField] private bool allowedToMove = true;
    [SerializeField]
    float moveSpeed = 5;
    [Header("Jumping")]
    public float JumpStrength = 30;
    public float jumpCooldown = 0f;
    [Header("Physics")]
    private float vertical;
    private float horizontal;
    private Rigidbody body;
    public bool canJump = true;
    [Header("Sound")]
    [SerializeField] private GameObject audioSource;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioMixerGroup group;
    [SerializeField] private float timeBetweenFoot;
    private float timeTillSound;
    private GameObject sourceEmpty;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (sourceEmpty == null)
        {
            sourceEmpty = GameObject.Find("AudioSources");
        }

    }
    private void FixedUpdate()
    {
        timeTillSound -= Time.deltaTime;
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
            if(velocity != new Vector3 (0, 0, 0) && timeTillSound < 0 && jumpCooldown <= 0)
            {
                FootstepSound();
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
    private void FootstepSound()
    {
        //Spawns an audio source and makes it play stuff
        if (audioSource != null)
        {
            AudioSource source = Instantiate(audioSource).GetComponent<AudioSource>();
            source.clip = footstepSound;
            source.outputAudioMixerGroup = group;
            source.Play();
            source.gameObject.GetComponent<TimeKillScript>().currentTime = footstepSound.length;
            source.transform.parent = sourceEmpty.transform;
            timeTillSound = timeBetweenFoot;
        }
    }
}

