using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Vector3 respawn = new Vector3(0, 0, 0);
    public Vector3 playerVelocity;
    public float playerSpeed = 8.0f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    
    // public float distanceToGround = 1.25f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    public Animator anim;
    public PauseMenu pm;
    public bool Run;
    public bool isGrounded;
    public bool falling;
    public AudioSource footSteps;
    public AudioSource landing;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pm.paused)
            {
                pm.Resume();
            }
            else
            {
                pm.Pause();
            }
        }

        if (!pm.paused)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (isOnGround()) {
                isGrounded = true;
                anim.SetBool("Run", false);
                // anim.SetBool("isGrounded", false);
                if (!landing.isPlaying && falling == true) {
                    falling = false;
                    landing.Play();
                    anim.SetBool("falling", false);
                }
            }
            else if (controller.isGrounded == false){
                Debug.Log("isGrounded is false");
                isGrounded = false;
            }
            anim.SetBool("isGrounded", isGrounded);
            
            // Movment
            if(direction.magnitude >= 0.1f)
            {
                Run = true;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
                if (isGrounded && !footSteps.isPlaying) {
                    footSteps.Play();
                }
            }
            else
                Run = false;
            anim.SetBool("Run", Run);
            
            // Jumping
            if (Input.GetKey("space") && isOnGround())
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                anim.SetTrigger("Jump");
            }
            
            // For falling
            if (playerVelocity.y > -9.81f)
                playerVelocity.y += gravity * Time.deltaTime;

            controller.Move(playerVelocity * Time.deltaTime);

            if (transform.position.y < -10) 
            {
                transform.position = respawn + new Vector3(0, 20, 0);
                anim.SetBool("Run", true);
                anim.SetBool("isGrounded", false);
                anim.SetBool("falling", true);
                falling = true;
                transform.parent = null;
            }
        }
    }
    bool isOnGround()
    {
        // Debug.Log("is on ground");
        // distanceToGround = GetComponent<Collider>().bounds.extents.y;
        // return Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
        return controller.isGrounded;
    }
}
