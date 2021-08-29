using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public Sounds[] backgroundMusic;
    private AudioSource _audiosource;
    public Sounds[] soundEffects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        foreach (Sounds s in soundEffects)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.current.gameOver += stopMusic;
        _audiosource = this.GetComponent<AudioSource>();
       // playMusic();
    }

    public void playMusic(string name)
    {
        Sounds s = Array.Find(backgroundMusic, sound => sound.name == name);
        if (s == null)
            return;
        // s.source.Play();
        _audiosource.clip = s.clip;
        _audiosource.volume = s.volume;
        _audiosource.loop = true;
        _audiosource.Play();
    }

    void stopMusic()
    {
        _audiosource.Pause();
    }

    public void playSound(string name)
    {
        Sounds s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
}
