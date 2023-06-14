using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text clockText;

    private void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);

        clockText.text = hour + ":" + minute;
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}