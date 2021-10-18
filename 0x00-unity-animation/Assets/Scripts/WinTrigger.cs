using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Collider player;
    public Timer timer;
    public Text timerText;
    public GameObject WinCanvas;
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
        }
    }
}
