using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winCanvas;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        Debug.Log("literally anyting out");
        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("literally anyting in");
        }
        else
        {        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
