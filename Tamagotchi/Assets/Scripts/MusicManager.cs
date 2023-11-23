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
    public AudioSource audiosource;
    public AudioClip[] songs;
    [SerializeField] private float songsPlayed;
    [SerializeField] private bool[] beenPlayed;
    private bool playing;

    public Slider slider;
    public float time;

    private Stack<int> played = new Stack<int>();
    private int currentSong;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
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

        slider.maxValue = audiosource.clip.length;
        slider.onValueChanged.AddListener(delegate { SliderChanged(); });

    }

    private void Update()
    {
        if (playing == false || audiosource.time >= audiosource.clip.length)
        {
            ChangeSong(Random.Range(0, songs.Length));
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
        slider.value = 0;
        slider.maxValue = audiosource.clip.length;
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
    
    void SliderChanged()
    {
        audiosource.time = slider.value;
    }
    
}
