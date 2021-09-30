using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Level01 ()
    {
        SceneManager.LoadScene("Level01");
    }
    public void Level02 ()
    {
        SceneManager.LoadScene("Level02");
    }
    public void Level03 ()
    {
        SceneManager.LoadScene("level03");
    }
    public void Exit ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
