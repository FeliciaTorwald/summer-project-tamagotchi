using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameHandler : MonoBehaviour
{
    public GameObject meny;
    public GameObject winMeny;
    public List<Enemy> enemies;
    private PlayerLives playerLives;
    private bool won;

    void Start()
    {
        won = true;
        playerLives = GameObject.Find("birdie").GetComponent<PlayerLives>();
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        enemies = new List<Enemy>();

        foreach (GameObject enemyObject in enemyObjects)
        {
            Enemy enemyComponent = enemyObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemies.Add(enemyComponent);
            }
        }
    }

    void Update()
    {
        if (enemies != null && enemies.Any(enemy => enemy != null && enemy.lose))
        {
            meny.SetActive(true);
        }
        if (playerLives.died)
        {
            meny.SetActive(true);
        }
       if( GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            winMeny.SetActive(true);
            Invoke("MainScene", 2);

            if(won)
            {
                won = false;
                SaveMoney();
            }
        }
    }
    public void MainScene()
    {
     SceneManager.LoadScene("MainScene");
     //MusicManager.ChangeSong(Random.Range(0, MusicManager.songs.Length), true);
    }
    public void ArcadeGame()
    {
        SceneManager.LoadScene("ArcadeShooter");
    }



    private void SaveMoney()
    {
        PlayerPrefs.SetInt("loadedMoney",PlayerPrefs.GetInt("loadedMoney") + 10);
    }


}
