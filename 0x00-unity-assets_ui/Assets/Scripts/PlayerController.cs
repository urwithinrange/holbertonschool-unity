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
    public float jumpHeight = 0.08f;
    public float gravity = -9.81f;
    
    public float distanceToGround = 0.4f; 

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    public PauseMenu pm;

    void Update()
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

            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("space") && isOnGround())
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
            if (playerVelocity.y > -9.81f)
                playerVelocity.y += gravity * Time.deltaTime;

            controller.Move(playerVelocity * Time.deltaTime);

            if (transform.position.y < -10) 
            {
                transform.position = respawn + new Vector3(0, 20, 0);
                transform.parent = null;
            }
        }
    }
    bool isOnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
