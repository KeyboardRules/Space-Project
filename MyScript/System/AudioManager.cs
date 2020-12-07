﻿using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.volume = sound.volumn;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }
        else
        {
            Destroy(gameObject);
            return;           
        }
        DontDestroyOnLoad(gameObject);
    }
    public void PlayNewTheme(string name)
    {
        if (sounds != instance.sounds) sounds = instance.sounds;
        foreach(Sound sound in sounds)
        {
            if (sound.name == name &&!sound.source.isPlaying)
            {
                sound.source.Play();
            }
            if (sound.name != name && sound.source.isPlaying)
            {
                sound.source.Stop();
            }
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.Log("null");
            return;
        }
            
        s.source.Play();
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    [Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0, 1f)] public float volumn=1f;
        [Range(0.1f, 3f)] public float pitch=1f;
        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}
