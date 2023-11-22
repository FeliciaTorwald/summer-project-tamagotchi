using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GachaMachineButton : MonoBehaviour
{
    private Animator animator;
    public Animator rollinAnimator;
    public MoneyCounter moneyCounter;
    public GameObject[] prizes;
    public Transform spawnLocation;
    public GameObject popUp;
    public GameObject prizeText;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        animator.SetTrigger("wiggle");
        rollinAnimator.SetTrigger("rollin");

        if (moneyCounter.money > 0)
        {
            moneyCounter.DecreaseMoneyToCounter();
            //popUp.SetActive(false);
            prizeText.SetActive(true);
            Invoke("Spawn", 2f);
        }
    }

    private void Spawn()
    {
        Instantiate(prizes[Random.Range(0, prizes.Length)], spawnLocation.position, spawnLocation.rotation);
        prizeText.SetActive(false);
    }
}
