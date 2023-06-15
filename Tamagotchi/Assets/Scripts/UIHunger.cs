using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class UIHunger : MonoBehaviour
{
    public GameObject icon;
    public List<Image> icons;
    public int maxHunger;
    public int hunger;
    DateTime currentTime = DateTime.Now;
    DateTime lastTimePlayed;
    public int counter;
    public int currentHunger;
    DateTime lastHungerTick;
    public int Hunger
    {
        get { return hunger; }  
    }

    public event Action HungerTaken;
    


    void Start()
    {
        hunger = maxHunger;
        //hunger = currentHunger;
        HungerTaken += UpdateIcons;
        currentHunger = PlayerPrefs.GetInt("Last Hunger");

        for(int i = 0; i < maxHunger;i++) 
        {
            GameObject iconObject = Instantiate(icon, this.transform);
            icons.Add(iconObject.GetComponent<Image>());
        }
        lastTimePlayed = DateTime.Parse(PlayerPrefs.GetString("Last Time Played"));
        TimeSpan difference = DateTime.Now.Subtract(lastTimePlayed);
        lastHungerTick = DateTime.Now;

        counter = difference.Minutes;
        hunger = currentHunger - counter;
        hunger = (int)MathF.Max(0, hunger);
    }
    private void Update()
    {
        TimeSpan difference = DateTime.Now.Subtract(lastHungerTick);
        if(difference.Minutes > 0)
        {
            hunger-= difference.Minutes;
            hunger = (int)MathF.Max(0, hunger);
            GetHungry();
        }
        ////currentHunger = icons.Count;//TODO save current heart and show at next start;

        

    }

    public void GetHungry()
    {
        lastHungerTick= DateTime.Now;
        if (HungerTaken != null)
        {
            HungerTaken();
        }
    }

    private void UpdateIcons()
    {
        int iconFill = Hunger;
        foreach(Image i in icons)
        {
            i.fillAmount = iconFill;
            iconFill -= 1;
        }
    }

    public void DecreaseHunger()
    {
        foreach (Image i in icons)
        {
            Destroy(i.gameObject);
        }
        icons.Clear();
        //currentHunger++;
        hunger++;
        hunger = Mathf.Min(hunger,maxHunger);
        for (int i = 0; i < hunger; i++)
        {
            GameObject h = Instantiate(icon, this.transform);
            icons.Add(h.GetComponent<Image>());
        }
        saveCurrentHunger();
    }

    public void SaveLastTimeFed()
    {
        PlayerPrefs.SetString("Last Time Played", DateTime.Now.ToString());
    }
    public void saveCurrentHunger()
    {;
        PlayerPrefs.SetInt("Last Hunger", hunger);
        SaveLastTimeFed();
    }
    public void OnApplicationQuit()
    {
        saveCurrentHunger();
    }

}
