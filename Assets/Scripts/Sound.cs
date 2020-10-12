using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip sound;
    [Range(0, 1)]
    public float volume;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
}
