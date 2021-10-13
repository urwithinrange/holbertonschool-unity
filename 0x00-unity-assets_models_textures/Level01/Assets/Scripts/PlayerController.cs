using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
	public Rigidbody rb;

    public float jumpSpeed = 10f;
    public float distanceToGround = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		// if (Input.GetKey("a"))
		// {
        //     rb.AddForce(-speed * Time.deltaTime, 0, 0);
		// }
        // if (Input.GetKey("d"))
        // {
		// 	rb.AddForce(speed * Time.deltaTime, 0, 0);
		// }
        // if (Input.GetKey("w"))
		// {
		// 	rb.AddForce(0, 0, speed * Time.deltaTime);
		// }
        // if (Input.GetKey("s"))
        // {
		//     rb.AddForce(0, 0, -speed * Time.deltaTime);
		// }
        // Debug.Log(isOnGround());

        if (Input.GetKey("space")&&isOnGround())
        {
            // rb.AddForce (0, 11f, 0);
            Vector3 jumpVelocity = new Vector3 (0, jumpSpeed, 0);
            rb.velocity = rb.velocity + jumpVelocity;
        }
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        rb.MovePosition (transform.position + movement);

    }
    bool isOnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
