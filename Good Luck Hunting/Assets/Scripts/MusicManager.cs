using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource mainAudioSource;
    public AudioClip startGameAudio;
    public AudioClip gamePlayAudio;
    public AudioClip gameOverAudio;

    // Start is called before the first frame update
    void Start()
    {
        mainAudioSource = GetComponent<AudioSource>();
        mainAudioSource.clip = startGameAudio;
        mainAudioSource.Play();
    }

    public void playStartGameAudio()
    {
        mainAudioSource.Stop();
        mainAudioSource.clip = startGameAudio;
        mainAudioSource.Play();
    }

    public void playGamePlayAudio()
    {
        mainAudioSource.Stop();
        mainAudioSource.clip = gamePlayAudio;
        mainAudioSource.Play();
    }

    public void playGameOverAudio()
    {
        mainAudioSource.Stop();
        mainAudioSource.clip = gameOverAudio;
        mainAudioSource.Play();
    }

    public void pauseAudio()
    {
        mainAudioSource.Pause();
    }
    public void playAudio()
    {
        mainAudioSource.Play();
    }

}
