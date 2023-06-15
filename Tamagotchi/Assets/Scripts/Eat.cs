using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public Animator animator;
    public UIHunger uiHunger;


    private void Yumyum()
    {
        animator.SetTrigger("doneeating");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            animator.SetTrigger("eatingcandy");
            Invoke("Yumyum", 3f);
            Destroy(other.gameObject);
            uiHunger.DecreaseHunger();
        }
    }
}
