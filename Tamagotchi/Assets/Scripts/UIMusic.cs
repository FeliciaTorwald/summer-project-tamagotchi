using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMusic : MonoBehaviour
{
    public Slider slider;

    public void MoveSlider(int num)
    {
        slider.value = num;
        num = 1;
    }
}
