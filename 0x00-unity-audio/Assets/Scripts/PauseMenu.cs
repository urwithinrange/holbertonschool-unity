using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public AudioMixerSnapshot isPaused;
    public AudioMixerSnapshot unpaused;

    public void Pause()
    {
        isPaused.TransitionTo(.01f);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        paused = true;
        gameObject.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        paused = false;
        gameObject.SetActive(false);
        unpaused.TransitionTo(.01f);
    }

    public void Restart() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        Time.timeScale = 1;
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options() {
        Time.timeScale = 1;
        paused = false;
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
    }
}
