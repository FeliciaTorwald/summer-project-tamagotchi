using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject explosion;
    public void Dying()
    {
        explosion.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
