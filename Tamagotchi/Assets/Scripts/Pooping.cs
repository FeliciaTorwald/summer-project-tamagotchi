using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooping : MonoBehaviour
{
    public GameObject poop;
    public Transform poopPlace;
    private void Start()
    {
        InvokeRepeating("Poopings", 10f,10f);
    }
    private void Poopings()
    {
        Instantiate(poop, poopPlace);
    }
}
