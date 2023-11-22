using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject birdie;
    private void Start()
    {
        Invoke("DelayBirdie", 3f);
    }
    private void DelayBirdie()
    {
        birdie.SetActive(true);
    }
    public void ArcadeGame()
    {
        SceneManager.LoadScene("ArcadeShooter");
    }
    private void ChangeToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void DelayIntro()
    {
        Invoke("ChangeToIntro", 3f);
    }
     
}
