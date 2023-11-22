using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public GameObject heart;

    private void Start()
    {
        Invoke("HeartAnimation", 5f);
        Invoke("ChangeToMainScene", 7f);
    }

    private void HeartAnimation()
    {
        heart.SetActive(true); ;
    }
    private void ChangeToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
