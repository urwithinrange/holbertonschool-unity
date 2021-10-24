using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Animator anim;
    public GameObject MainCamera;
    public GameObject TimerCanvas;
    public GameObject Player;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        // anim.SetInteger("Level", SceneManager.GetActiveScene().buildIndex);
        // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                Debug.Log("Before intro");
                MainCamera.SetActive(true);
                TimerCanvas.SetActive(true);
                // gameObject.SetActive(false);
                Camera.SetActive(false);
                Player.gameObject.GetComponent<PlayerController>().enabled = true;
                Debug.Log("After intro");
            }
    }
}
