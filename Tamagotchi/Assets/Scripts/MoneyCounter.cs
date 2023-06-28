using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoneyCounter : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public int money;
    public GameObject coin;
    public Transform goldCounter;
    public Transform gachaMachine;
    bool flying;

    private void Start()
    {
        Load();
    }
    private void Update()
    {
        if(flying)
        {
            GameObject spawnedCoin = Instantiate(coin);


        }
    }
    public void AddMoneyToCounter()
    {
        money += 10;
        
        goldText.text = string.Format("{0:000}", money);
    }
    public void DecreaseMoneyToCounter()
    {
        money -= 1;

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
