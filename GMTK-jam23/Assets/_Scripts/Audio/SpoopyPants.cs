using UnityEngine;
using System;
using System.Collections.Generic;

public class SpoopyPants : MonoBehaviour
{



    [SerializeField] Sound s;
    List<AudioSource> sounds = new List<AudioSource>();

    private void Start()
    {
        
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.loop = s.loop;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.outputAudioMixerGroup = s.mixer;

        sounds.Add(s.source);
    }




    public void Play()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (!sounds[i].isPlaying)
            {
                sounds[i].Play();
                return;
            }
        }
        var _source = gameObject.AddComponent<AudioSource>();
        sounds.Add(_source);
        _source.clip = s.clip;
        _source.loop = s.loop;
        _source.volume = s.volume;
        _source.pitch = s.pitch;
        _source.outputAudioMixerGroup = s.mixer;
        _source.Play(); 
    }
}