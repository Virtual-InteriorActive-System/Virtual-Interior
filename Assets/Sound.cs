﻿using UnityEngine.Audio;
using UnityEngine;

public class Sound : MonoBehaviour {


    public string Name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [HideInInspector]
    public AudioSource source;
}
