using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaMachineButton : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        animator.SetTrigger("wiggle");
    }
}
