using UnityEngine;
using System.Collections;

public class TimerTrigger : MonoBehaviour
{
    // public Collider player;
    public Timer timer;
    void OnTriggerExit(Collider other)
    {
         if(other.gameObject.tag == "player")
         {
            timer.enabled = true;
         }
    }
}
