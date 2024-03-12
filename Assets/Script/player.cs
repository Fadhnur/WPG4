using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float horizontal; 
    private float vertical;
    private float speed = 5.0f;
    private Vector3 moveDirection;
    public bool isGrounded;

    public bool isWalking;
    public bool isRunning;
    public Rigidbody rb;

    public AudioSource runningSound;

    public AudioSource footStepSound;
    public float footStepInterval = 0.1f;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       isGrounded = false;

       //inisialisasi audio di dalam game object
       //footStepSound = GetComponent<AudioSource>();
       //runningSound = GetComponent<AudioSource>();

       // Lock And Hide Cursor:
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * speed * Time.deltaTime); 

        //berlari
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && isGrounded ){
            transform.position += transform.forward * Time.deltaTime * speed;
            PlayRunningSound();
            isRunning = true;
            isWalking = false;
        }
    
        //berjalan
        else if(moveDirection.magnitude > 0 && isGrounded)
        {
            PlayFootStepSound();
            isWalking = true;
            isRunning = false;
        }

        //melompat
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded){
            rb.velocity = new Vector3(0,5,0);
            //isGrounded = true;
        }

    }

    void PlayFootStepSound()
    {
        //memastikan suara berjalan tidak menyala
        if(!footStepSound.isPlaying && isWalking)
        {
            //menyalakan suara berjalan
            footStepSound.Play();
            Invoke("PlayFootStepSound", footStepInterval);
        }
    }

    void PlayRunningSound()
    {   
        //memastikan suara berlari tidak menyala dan suara berjalan menyala
        if(!runningSound.isPlaying && isRunning)
        {   
            //menyalakan suara berlari
            runningSound.Play();
            //Invoke("PlayRunningSound", footStepInterval);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
