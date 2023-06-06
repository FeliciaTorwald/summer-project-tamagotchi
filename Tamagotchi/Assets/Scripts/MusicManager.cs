using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get { return instance; }
    }
    private AudioSource audiosource;
    public AudioClip[] songs;
    [SerializeField] private float trackTimer;
    [SerializeField] private float songsPlayed;
    [SerializeField] private bool[] beenPlayed;
    private bool playing;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(this.gameObject);
    }
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        beenPlayed = new bool[songs.Length];

        if (!audiosource.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    private void Update()
    {
        if (playing == false || trackTimer >= audiosource.clip.length)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }

        if (playing == true)
        {
            trackTimer += 1 * Time.deltaTime;
        }

        ResetShuffle();
    }


    public void ChangeSong(int songPicked)
    {
        if (!beenPlayed[songPicked])
        {
            trackTimer = 0;
            songsPlayed++;
            beenPlayed[songPicked] = true;
            audiosource.clip = songs[songPicked];
            audiosource.Play();
            playing = true;
        }
        else
        {
            audiosource.Stop();
            playing = false;
        }

    }
    public void PauseSong()
    {
        audiosource.Pause();
        trackTimer = 0;
    }

    public void PlaySong()
    {
        audiosource.Play();
        trackTimer = 0;
    }

    public void PreviousSong()
    {
        
    }


    public void ResetShuffle()
    {

        if (songsPlayed == songs.Length)
        {
            songsPlayed = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                if (i == songs.Length)
                    break;
                else
                    beenPlayed[i] = false;
            }
        }

    }
}
