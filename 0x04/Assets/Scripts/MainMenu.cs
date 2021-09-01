using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public Button playButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(QuitMaze);
        playButton.onClick.AddListener(PlayMaze);
    }
    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        SceneManager.LoadScene("Maze");
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
