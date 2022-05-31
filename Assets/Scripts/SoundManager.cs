using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Pause single clip through the sound effect source.
    public void Pause()
    {
        EffectsSource.Pause();
    }

    // Pause single clip through the music source.
    public void PauseMusic()
    {
        MusicSource.Pause();
    }

    // Stop single clip through the sound effect source.
    public void Stop()
    {
        EffectsSource.Stop();
    }

    // Stop single clip through the music source.
    public void StopMusic()
    {
        MusicSource.Stop();
    }
}
