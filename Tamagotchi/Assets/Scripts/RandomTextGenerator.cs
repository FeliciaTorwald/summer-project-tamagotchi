using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.iOS;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class RandomTextGenerator : MonoBehaviour
{
    public TextMeshProUGUI prettyText;
    string[] messages = { "you look cute today", "the sun doesnt even outdo your brightness", "venus blessed you I see","everyday I gaze upon you", "eternity doesnt seem to be that long with you",
        "you spark like a thunderstorm","is this a dream?","you're sweet like sugar","with you awake this will be a good day","who am I? your secret admirer", "luminous like the moon",
        "you're finally awake","like a flower I hope you're ready to get picked","you smell like a flowerfield of roses","was that you falling or a star?"};
    [SerializeField] private bool[] beenRead;
    [SerializeField] private float textRead;
    private int counter;
    string randomText;
    public Animator animator;
    public GameObject notice;

    void Start()
    {
        beenRead = new bool[messages.Length];
        Invoke("Explosion", 3.9f);
    }

    private void Explosion()
    {
        animator.SetTrigger("explode");
        notice.SetActive(true);
    }
    public void GenerateRandomText()
    {
        randomText = messages[Random.Range(0, messages.Length)];
            prettyText.text = randomText;
        //textRead++;
        //beenRead[int.Parse(randomText)] = true;

        ////prettyText.text = randomText;

        //while (beenRead[int.Parse(randomText)])
        //{
        //    //randomText = messages[Random.Range(0, messages.Length)];
        //    counter++;
        //    if (counter >= 100)
        //    {
        //        ResetShuffle();
        //    }
        //}
    }

    public void ResetShuffle()
    {
        textRead = 0;
        for (int i = 0; i < messages.Length; i++)
        {
            if (i == messages.Length)
                break;
            else
                beenRead[i] = false;
        }
    }
}
