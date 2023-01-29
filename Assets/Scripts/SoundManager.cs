using System.Collections;
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

    public float BGMVolum;
    public float SFXVolum;

    public AudioSource bgm;
    private void Awake()
    {
        for (int i = 0; i < ((int)ESoundSources.END); i++)
        {
            audioSources.Add(Resources.Load<AudioClip>("Audio/" + ((ESoundSources)i).ToString()));
        }

        if(audioSources.Count > 0)
        PlaySound(ESoundSources.BGM);
    }

    public void PlaySound(ESoundSources source)
    {

        GameObject go = new GameObject("sound");

        AudioSource audio = go.AddComponent<AudioSource>();
        audio.clip = audioSources[((int)source)];

        if (source == ESoundSources.BGM)
        {
            bgm = audio;
            audio.volume = BGMVolum;
            audio.loop = true;
        }
        else audio.volume = SFXVolum;
        audio.Play();

        if (source != ESoundSources.BGM)
            Destroy(go, audio.clip.length);
    }

}
