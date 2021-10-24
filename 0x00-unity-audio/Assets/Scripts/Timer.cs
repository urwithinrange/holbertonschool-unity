using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text FinalTime;
    public GameObject TimerStart;
    public GameObject TimerCanvas;
    float totalTime = 0f;
    bool running = false;

    // Update is called once per frame
    void Update()
    {
        if (running) {
            totalTime += Time.deltaTime;
            timerText.text = $"{(int)totalTime / 60}:{(totalTime % 60).ToString("00.00")}";
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if(Other.gameObject == TimerStart.gameObject)
        {
            // Debug.Log("anything");
            running = true;
        } 
    }

    public void Stop()
    {
        running = false;
    }

    public void Win()
    {
        Time.timeScale = 1f;
        TimerCanvas.SetActive(false);
        FinalTime.text = timerText.text;
        timerText.text = "";
    }
}
