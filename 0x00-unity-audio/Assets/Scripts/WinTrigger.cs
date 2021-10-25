using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class WinTrigger : MonoBehaviour
{
    public Collider player;
    public Timer timer;
    public Text timerText;
    public GameObject WinCanvas;
    public AudioSource BGMl1;
    public AudioSource win;

    void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            timer.Stop();
            timerText.fontSize = 80;
            timerText.color = Color.green;
            WinCanvas.SetActive(true);
            Time.timeScale = 0;
            timer.Win();
            BGMl1.Stop();
            win.Play();
        }
    }
}
