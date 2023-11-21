using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosion;
    public bool died;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                lives -= 1;
            for(int i = 0; i < livesUI.Length; i++)
            {
                if (i < lives)
                {
                    livesUI[i].enabled = true;
                }
                else
                {
                    livesUI[i].enabled = false;
                }
            }
                if(lives <= 0)
                {
                explosion.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;   
                died = true;
                Invoke("Die", 0.5f);
                }

            }
        }

    public void Die()
    {
        Destroy(gameObject);

    }
}
