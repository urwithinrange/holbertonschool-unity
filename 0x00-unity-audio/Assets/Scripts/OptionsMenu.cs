using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public bool isInverted;
    public Toggle inverted;
    public Slider bgm;
    public static float bgmSlider = 1f;
    public Slider sfx;
    public static float sfxSlider = 1f;
    public AudioMixer master;
 
    public void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == 1)
        {
            inverted.isOn = true;
            isInverted = true;
        }
        else
        {
            inverted.isOn = false;
            isInverted = false;
        }
        bgm.value = bgmSlider;
        // PlayerPrefs.GetFloat("BGMVolume");
        sfx.value = sfxSlider;
        // PlayerPrefs.GetFloat("SFXVolume");
    }
    public void Back()
    {
        SetBGMVol(PlayerPrefs.GetFloat("BGMVolume"));
        SetSFXVol(PlayerPrefs.GetFloat("SFXVolume"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
    }
    public void Apply()
    {
        PlayerPrefs.SetFloat("BGMVolume", bgm.value);
        PlayerPrefs.SetFloat("SFXVolume", sfx.value);
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
        if (inverted.isOn)
        {
            PlayerPrefs.SetInt("Inverted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Inverted", 0);
        }
    }
    public void SetBGMVol(float vol) {
        bgmSlider = vol;
        master.SetFloat("bgmVol", LinearToDecibel(vol));
    }
    public void SetSFXVol(float vol) {
        sfxSlider = vol;
        master.SetFloat("sfxVol", LinearToDecibel(vol));
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
