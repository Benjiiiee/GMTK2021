using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public string timer;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        time += Time.deltaTime;
        timer = time.ToString("F2");
    }
}
