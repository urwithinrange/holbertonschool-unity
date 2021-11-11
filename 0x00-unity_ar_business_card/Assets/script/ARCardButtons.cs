using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARCardButtons : MonoBehaviour
{
    public string linkedInURL;
    public string githubURL;
    public string twitterURL;
    
    // public GameObject LinkCanvas;
    // public Animator anim;
   
    // void Start()
    // {
    //     anim = GetComponent<Animator>();
    // }
    // void Update()
    // {
    //     if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
    //     {
    //         anim.gameObject.SetActive(true);
    //     }
    //     if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
    //     {
    //         anim.gameObject.SetActive(false);
    //     }
    // }

    public void LinkedIn()
    {
        Debug.Log("LinkedIn");
        // if (Input.GetMouseButtonDown(0))
        Application.OpenURL(linkedInURL);
    }
    public void Email()
    {
        Debug.Log("Email");
        // if (Input.GetButtonDown("EmailButton"))
        System.Diagnostics.Process.Start("mailto:2334@holbertonschool.com?body=Nice ARcard bro!!");
    }

    public void GitHub()
    {
        Debug.Log("GitHub");
        // if (Input.GetButtonDown("GitHubButton"))
        Application.OpenURL(githubURL);
    }

    public void Twitter()
    {
        Debug.Log("Twitter");
        // if (Input.GetButtonDown("TwitterButton"))
        Application.OpenURL(twitterURL);
    }
}
