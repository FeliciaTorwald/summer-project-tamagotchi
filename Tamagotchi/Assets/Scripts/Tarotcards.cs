using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tarotcards : MonoBehaviour
{
    public Transform [] spawnLocation;
    public GameObject [] tarotcards;

    public List<GameObject> pickedUpCards = new List<GameObject>();

    private GameObject pickedCard;
    public TextMeshProUGUI winText;

    public int counter;
    public int whiteCounter;
    public int blueCounter;
    public int yellowCounter;

    public bool win;

    public MoneyCounter moneyCounter;


    public void PickCard()
    {
        if (counter == 0)
        {
        pickedCard = Instantiate(tarotcards[Random.Range(0, tarotcards.Length)], spawnLocation[0].position, spawnLocation[0].rotation);
        pickedUpCards.Add(pickedCard);
        }
        if (counter == 1)
        {
            pickedCard = Instantiate(tarotcards[Random.Range(0, tarotcards.Length)], spawnLocation[1].position, spawnLocation[1].rotation);
            pickedUpCards.Add(pickedCard);
        }
        if (counter == 2)
        {
            pickedCard = Instantiate(tarotcards[Random.Range(0, tarotcards.Length)], spawnLocation[2].position, spawnLocation[2].rotation);
            pickedUpCards.Add(pickedCard);
        }

        counter++;
        RemoveCard();
        WinningCheck();
    }

    public void RemoveCard()
    {
        if (counter == 4)
        {
            while (counter > 1)
            {
            GameObject.Destroy(pickedUpCards[0]);
            pickedUpCards.RemoveAt(0);
            counter--;
                if(counter == 1)
                {
                    counter--;
                }
            }
            if(win == false)
            {
                whiteCounter = 0;
                blueCounter = 0;
                yellowCounter = 0;
                winText.text = string.Format("");
            }
        }
    }

    public void WinningCheck()
    {
        win = false;

        if(whiteCounter == 3)
        {
            win = true;
            //moneyCounter.AddMoneyToCounter();
        }
        if (blueCounter == 3)
        {
            win = true;
            //moneyCounter.AddMoneyToCounter();
        }
        if (yellowCounter == 3)
        {
            win = true;
            //moneyCounter.AddMoneyToCounter();
        }

        if (win == true)
        {
            moneyCounter.AddMoneyToCounter();
            winText.text = string.Format("Good fortune is with you");
            win = false;
        }
    }
}
