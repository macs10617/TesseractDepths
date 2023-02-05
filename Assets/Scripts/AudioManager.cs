using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public struct StringClipPair
{
    public string ClipId;
    public AudioClip Clip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioClip _backgroundMusic;

    [SerializeField] private List<StringClipPair> _clips;

    public static AudioManager Instance => _instance;
    private static AudioManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize();
    }

    public void Initialize()
    {
        PlayBackgroundMusic(_backgroundMusic);
    }

    public void PlaySoundEffect(string clipId)
    {
        PlaySoundEffect(_clips.FirstOrDefault(x => x.ClipId == clipId).Clip);
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffect.clip = clip;
        soundEffect.Play();
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }
}