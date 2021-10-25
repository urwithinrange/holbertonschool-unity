using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer master;
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void Start() {
        master.SetFloat("bgmVol", LinearToDecibel(PlayerPrefs.GetFloat("BGMVolume")));
        master.SetFloat("sfxVol", LinearToDecibel(PlayerPrefs.GetFloat("SFXVolume")));
    }

    private float LinearToDecibel(float linear) {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }
}
