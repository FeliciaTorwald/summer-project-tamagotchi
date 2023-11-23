using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightDayChecker : MonoBehaviour
{
    public GameObject nightBackground;
    public GameObject dayBackground;

    void Update()
    {
        DateTime time = DateTime.Now;
        if(time.Hour > 17 || time.Hour < 11)
        {
            dayBackground.gameObject.SetActive(false);
            nightBackground.gameObject.SetActive(true);
        }
        else
        {
            dayBackground.gameObject.SetActive(true);
            nightBackground.gameObject.SetActive(false);
        }
       
    }
}
