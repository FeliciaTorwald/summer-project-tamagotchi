using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionalState : MonoBehaviour
{
    private Animator animator;

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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            animator.SetBool("afraid", false);
        }
    }
}
