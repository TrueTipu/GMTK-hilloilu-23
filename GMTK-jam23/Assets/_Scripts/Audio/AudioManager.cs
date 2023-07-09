using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioManager.instance.Play("Ääni tähän");

    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixer;

        }
        DontDestroyOnLoad(gameObject);


    }





    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();


    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }
    public void PlayRandom(string[] names)
    {
        string name = names[Mathf.FloorToInt(UnityEngine.Random.Range(0, names.Length-0.1f))];
        Debug.Log(name);
        Play(name);
    }
    public void PlayOnLoop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.source.isPlaying) return;
        s.source.Play();
    }
}