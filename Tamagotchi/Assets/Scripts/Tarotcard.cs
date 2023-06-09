using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarotcard : MonoBehaviour
{
    public TypeOfTarot typeOfTarot;

    Tarotcards tarotcards;

    public enum TypeOfTarot
    {
        White,
        Blue,
        Yellow,
    }
    private void Awake()
    {
       tarotcards = FindObjectOfType<Tarotcards>();
       CountCards();
    }

    public void CountCards()
    {
      if(typeOfTarot == TypeOfTarot.White)
        {
            tarotcards.GetComponent<Tarotcards>().whiteCounter += 1;
        }
        if (typeOfTarot == TypeOfTarot.Blue)
        {
            tarotcards.GetComponent<Tarotcards>().blueCounter++;
        }
        if (typeOfTarot == TypeOfTarot.Yellow)
        {
            tarotcards.yellowCounter++;
        }
    }
}
