using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    AudioSource[] sources = new AudioSource[6];

    private void OnEnable()
    {
        if (!AudioManager.Instance.IsPlaying("M1"))
        {
            sources[0] = AudioManager.Instance.PlayOnLoop("M1");
            sources[1] = AudioManager.Instance.PlayOnLoop("M2");
            sources[2] = AudioManager.Instance.PlayOnLoop("M3");
            sources[3] = AudioManager.Instance.PlayOnLoop("M4");
            sources[4] = AudioManager.Instance.PlayOnLoop("M5");
            sources[5] = AudioManager.Instance.PlayOnLoop("M6");
        }
        switch (GameManager.Instance.Phase)
        {
            case 0:
                for (int i = 0; i < 1; i++)
                {
                    sources[i].volume = 1;
                }
                for (int i = 1; i < 6; i++)
                {
                    sources[i].volume = 0;
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    sources[i].volume = 1;
                }
                for (int i = 3; i < 6; i++)
                {
                    sources[i].volume = 0;
                }
                break;
            case 3:
                for (int i = 0; i < 6; i++)
                {
                    sources[i].volume = 1;
                }
                break;
        }
    }

    public void SetSourceActive(int stage)
    {
        for (int i = 0; i < stage; i++)
        {
            sources[i].volume = 1;
        }
        for (int i = stage; i < 6; i++)
        {
            sources[i].volume = 0;
        }
    }

}