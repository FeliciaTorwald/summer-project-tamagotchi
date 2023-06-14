using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIHunger : MonoBehaviour
{
    public GameObject icon;
    public List<Image> icons;
    public int maxHunger;
    public int hunger;
    public int Hunger
    {
        get { return hunger; }  
    }

    public event Action HungerTaken;
    


    void Start()
    {
        hunger = maxHunger;
        HungerTaken += UpdateIcons;

        for(int i = 0; i < maxHunger;i++) 
        {
            GameObject iconObject = Instantiate(icon, this.transform);
            icons.Add(iconObject.GetComponent<Image>());
        }
    }

    public void GetHungry()
    {
        if (hunger <= 0)
        {
            return;
        }
            hunger -= 1;
        if(HungerTaken != null)
        {
            HungerTaken();
        }
    }

    private void UpdateIcons()
    {
        int iconFill = Hunger;
        Debug.Log(iconFill);
        foreach(Image i in icons)
        {
            i.fillAmount = iconFill;
            iconFill -= 1;
        }
    }

    void DecreaseHunger()
    {
        foreach (Image i in icons)
        {
            Destroy(i.gameObject);
        }
        icons.Clear();

        for (int i = 0; i < maxHunger; i++)
        {
            GameObject h = Instantiate(icon, this.transform);
            icons.Add(h.GetComponent<Image>());
        }
    }

}
