using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get { return instance; }
    }
    private AudioSource audiosource;
    public AudioClip[] songs;
    [SerializeField] private float songsPlayed;
    [SerializeField] private bool[] beenPlayed;
    private bool playing;

    public Slider slider;
    public float gameTime;
    public bool stopTimer;
    public float time;

    private Stack<int> played = new Stack<int>();
    private int currentSong;

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
            ChangeSong(Random.Range(0, songs.Length), true);
        }

        stopTimer = false;
        slider.maxValue = audiosource.clip.length;
        slider.onValueChanged.AddListener(delegate { SliderChanged(); });

    }

    private void Update()
    {
        if (playing == false || audiosource.time >= audiosource.clip.length)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }


        if (stopTimer == false)
        {
            slider.value = time;
            time = gameTime - Time.time;//change this to delta time, time.time checks when the application starts
            //time = gameTime - Time.deltaTime;//what the heck its barely changing
            //timeRemaining -= Time.deltaTime;

        }
        if (time <= 0)
        {
            stopTimer = true;
        }
        slider.value = audiosource.time;
    }


    public void ChangeSong(int songPicked, bool previous = false)
    {
        if (previous == false)
        {
            played.Push(currentSong);
        }
        songsPlayed++;
        beenPlayed[songPicked] = true;
        audiosource.clip = songs[songPicked];
        currentSong = songPicked;
        audiosource.Play();
        playing = true;

    }
    public void PauseSong()
    {
        audiosource.Pause();
    }

    public void PlaySong()
    {
        audiosource.Play();
    }

    public void PreviousSong()
    {
        if (played.Count > 0)
        {
            ChangeSong(played.Pop(), true);
        }
    }

    public void NextSong()
    {
        int selectedSong = Random.Range(0, songs.Length);
        int counter = 0;
        while (beenPlayed[selectedSong])
        {
            selectedSong = Random.Range(0, songs.Length);
            counter++;
            if (counter >= 100)
            {
                ResetShuffle();
            }
        }
        ChangeSong(selectedSong, false);
    }
    public void ResetShuffle()
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

    public void ResetTimer()
    {
        stopTimer = true;
        Invoke("StartTimer", 0.5f);
    }

    void SliderChanged()
    {
        audiosource.time = slider.value;
    }
    public void StartTimer()
    {
        stopTimer = false;
    }
}
