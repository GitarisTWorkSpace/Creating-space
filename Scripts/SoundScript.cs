using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{
    public AudioMixerGroup Mixer;

    private float MusicVolume;
    private float SoundVolume;

    public void MusicVolumeChange(float value)
    {
        MusicVolume = value;
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, value));
    }

    public void SoundVolumeChange(float value)
    {
        SoundVolume = value;
        Mixer.audioMixer.SetFloat("SoundVolume", Mathf.Lerp(-80, 0, value));
    }
}
