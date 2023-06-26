using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionalState : MonoBehaviour
{
    private Animator animator;
    public GameObject dimmerSleep;

    private void Start()
    {
       animator =  GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            animator.SetBool("afraid", true);
        }

        if (other.CompareTag("Teddy"))
        {
            animator.SetBool("sleeping", true);
            dimmerSleep.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teddy"))
        {
            animator.SetBool("sleeping", false);
            dimmerSleep.SetActive(false);
        }

        if (other.CompareTag("Ball"))
        {
            animator.SetBool("afraid", false);
        }
    }
}
