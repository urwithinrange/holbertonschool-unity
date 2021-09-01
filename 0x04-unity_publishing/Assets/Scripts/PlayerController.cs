using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 4000f;
	public Rigidbody rb;
	private int score = 0;
    public Text scoreText;
	public int health = 5;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		if (Input.GetKey("a"))
		{
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey("d"))
        {
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
        if (Input.GetKey("s"))
        {
		    rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
        if (health <= 0)
        {
            winLoseBG.transform.gameObject.SetActive(true);
            winLoseBG.color = Color.red;
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
        }
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>().tag == "Pickup")
        {
            score++;
            SetScoreText();
            // Debug.Log($"Score: {score}");
            // Object.Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.GetComponent<Collider>().tag == "Trap")
        {
            health--;
            SetHealthText();
            // Debug.Log($"Health: {health}");
        }

        if (other.GetComponent<Collider>().tag == "Goal")
        {
            winLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseBG.transform.gameObject.SetActive(true);
            // Debug.Log("You Win!");
        }
	}
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
