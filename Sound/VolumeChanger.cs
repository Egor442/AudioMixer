using System;
using UnityEngine.Audio;

public class VolumeChanger
{
    private AudioMixer _audioMixer;
    private float _multiplier;
    private string _volumeParameter;

    public VolumeChanger(AudioMixer audioMixer, float multiplier, string volumeParameter)
    {
        _audioMixer = audioMixer;
        _multiplier = multiplier;
        _volumeParameter = volumeParameter;
    }

    public void ChangeVolume(float volume)
    {
        float volumeValue = (float)Math.Log10(volume) * _multiplier;
        _audioMixer.SetFloat(_volumeParameter, volumeValue);
    }
}