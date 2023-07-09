using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}