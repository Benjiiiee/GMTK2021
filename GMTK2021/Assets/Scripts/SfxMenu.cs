using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxMenu : MonoBehaviour
{
    public AudioSource mySource1;
    public AudioSource mySource2;

    public float timer = 1.5f;
    public bool timerRunning = true;

    void Update()
    {
        if (timerRunning) { 
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = 0;
                timerRunning = false;
                mySource1.PlayDelayed(0.1f);
                mySource2.Play();
            }
        }
    }
}
