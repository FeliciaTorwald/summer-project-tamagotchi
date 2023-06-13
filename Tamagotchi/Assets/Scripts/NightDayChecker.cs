using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class NightDayChecker : MonoBehaviour
{
    public GameObject nightBackground;
    public GameObject dayBackground;
    // Start is called before the first frame update
    void FixedUpdate()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
