using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;

        foreach(Sound s in sounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log(s.name);
        s.source.PlayOneShot(s.clip);
    }

    public void Select()
    {
        Play("Select");
    }

    public void Cancel()
    {
        Play("Cancel");
    }
}