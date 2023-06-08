using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject prefab;
    public Animator animator;
    private GameObject candy;

    public void Spawn()
    {
        candy = Instantiate(prefab);
        gameObject.SetActive(false);
        animator.SetTrigger("return");
    }

    public void Patience()
    {
        Invoke("Spawn", 7.5f);
    }

    public void Destroy()
    {
        Destroy(candy);
    }
}
