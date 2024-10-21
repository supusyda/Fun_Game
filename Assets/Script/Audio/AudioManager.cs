using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum AudioType
{
    Music,
    HurtVfx,
    SlashSfx,
    FootStepSfx,
    ExplosionSfx,
    ShotSfx,
    DeathSfx
}
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField]
    List<AudioTypeNames> playerAudio = new();
    [SerializeField]

    List<AudioTypeNames> allyAudio = new();

    [SerializeField] AudioClip BGMusic;

    public string _SLASH_SFX = "Slash";
    public string _HURT_SFX = "Hurt";
    public string _BOW = "Bow";
    public string _LEVELUP = "LevelUp";

    public string _EXPLOSIVE = "Explosive";

    // public string _FOOTSTEP_SFX = "FootStep";
    // public string _DEATH_SFX = "Death";
    // public string _SHOT_SFX = "Slash";


    private AudioSource _audioSource;
    public AudioSource AudioSource
    {
        get => _audioSource;
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayBGMusic();

    }
    public void PlayAudioAlly(string audioName)
    {
        AudioClip clip = allyAudio.Find(audio => audio.audioName == audioName).audio;

        _audioSource.PlayOneShot(clip);
    }
    public void PlayAudio(string audioName, float volume = 1f)
    {
        AudioClip clip = playerAudio.Find(audio => audio.audioName == audioName).audio;
        // clip. = volume;
        _audioSource.PlayOneShot(clip);
    }

    public void PlayBGMusic()
    {
        float volume = .2f;
        _audioSource.clip = BGMusic;
        _audioSource.volume = volume;
        _audioSource.Play();
        Debug.Log(_audioSource.isPlaying);
    }
    public void StopBGMusic()
    {
        _audioSource.Stop();
    }
}
[Serializable]
struct AudioTypeNames
{
    [SerializeField] public AudioClip audio;
    [SerializeField] public string audioName;

}
