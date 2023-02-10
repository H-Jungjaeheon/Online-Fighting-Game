using System.Collections.Generic;
using UnityEngine;

public enum ESoundSources
{
    BGM,
    BUTTON,
    END
}

public class SoundManager : MonoBehaviour
{
    private List<AudioClip> audioSources = new List<AudioClip>();
    public float MasterVolum;

    public AudioSource bgm;

    private void Awake()
    {
        for (int i = 0; i < (int)ESoundSources.END; i++)
        {
            audioSources.Add(Resources.Load<AudioClip>("Audio/" + ((ESoundSources)i).ToString()));
        }

        PlaySound(ESoundSources.BGM);
    }

    public void PlaySound(ESoundSources source)
    {
        AudioClip audioClip = audioSources[(int)source];
        bool loop = (source == ESoundSources.BGM);

        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = audioClip;
        audio.volume = MasterVolum;
        audio.loop = loop;
        audio.Play();

        if (source == ESoundSources.BGM)
        {
            bgm = audio;
        }
        else
        {
            Destroy(audio, audioClip.length);
        }
    }
}