using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider slider;
    public float gameTime;
    public bool stopTimer;
    private AudioSource audioSource;
    public float time;
    float timeRemaining;

    private void Start()
    {
        timeRemaining = gameTime;
        audioSource = GetComponent<AudioSource>();
        stopTimer = false;
        slider.maxValue = audioSource.clip.length;

    }
    private void Update()
    {
        if (stopTimer == false)
        {
            slider.value = time;
            time = gameTime - Time.time;//change this to delta time, time.time checks when the application starts
            //time = gameTime - Time.deltaTime;//what the heck its barely changing
            //timeRemaining -= Time.deltaTime;

        }
        if (time <= 0)
        {
            stopTimer = true;
        }
    }

    public void ResetTimer()
    {
        stopTimer = true;
        time = 125;
        gameTime = 125;
        slider.maxValue = gameTime;
        slider.value = gameTime;
        Invoke("StartTimer",0.5f);
    }
    public void StartTimer()
    {
        stopTimer = false;
    }
}
