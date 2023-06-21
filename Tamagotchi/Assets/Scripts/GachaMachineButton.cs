using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaMachineButton : MonoBehaviour
{
    private Animator animator;
    public MoneyCounter moneyCounter;
    public GameObject[] prizes;
    public Transform spawnLocation;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        animator.SetTrigger("wiggle");

        if(moneyCounter.money > 0)
        {
            moneyCounter.DecreaseMoneyToCounter();  
            Instantiate(prizes[Random.Range(0, prizes.Length)], spawnLocation.position, spawnLocation.rotation);
        }
    }
}
