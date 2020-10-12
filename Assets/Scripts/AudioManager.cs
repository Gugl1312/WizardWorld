using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        Play("Menu");
    }
    public void Play(string soundName)
    {
        foreach (Sound s in sounds)
        {
            if(s.Name == soundName)
            {
                s.source.Play();
            }
            else
            {
                Debug.LogWarning("Sound with name " + soundName + " doesn't exist.");
            }
        }        
    }
}
