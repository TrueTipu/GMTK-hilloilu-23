using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicPlayer : Singleton<AudioManager>
{

    [SerializeField] AudioManager audioManager;

    public Sound[] layers;





    void Awake()
    {


        foreach (Sound s in layers)
        {
            s.source = audioManager.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixer;

        }
    }

}