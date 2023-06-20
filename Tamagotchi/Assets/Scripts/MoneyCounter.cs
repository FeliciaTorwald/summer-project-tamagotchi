using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public int money;
    private void Start()
    {
        Load();
    }
    public void AddMoneyToCounter()
    {
        money += 1;
        
        goldText.text = string.Format("{0:000}", money);
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("loadedMoney", money);
    }

    private void Load()
    {
        money = PlayerPrefs.GetInt("loadedMoney");
        Debug.Log(PlayerPrefs.GetInt("loadedMoney"));
        goldText.text = string.Format("{0:000}", money);
    }
}
