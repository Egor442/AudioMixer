using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerPanel : MonoBehaviour
{
    private const string MasterVolumeParameter = "MasterVolume";
    private const string MusicVolumeParameter = "MusicVolume";
    private const string EffectsVolumeParameter = "EffectsVolume";

    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;

    [SerializeField] private Button _toggle;

    [SerializeField] private float _multiplier;

    private bool _enable = true;

    private VolumeChanger _masterVolumeChanger;
    private VolumeChanger _musicVolumeChanger;
    private VolumeChanger _effectsVolumeChanger;

    private void Awake()
    {
        _masterVolumeChanger = new VolumeChanger(_audioMixer, _multiplier, MasterVolumeParameter);
        _musicVolumeChanger = new VolumeChanger(_audioMixer, _multiplier, MusicVolumeParameter);
        _effectsVolumeChanger = new VolumeChanger(_audioMixer, _multiplier, EffectsVolumeParameter);
    }

    private void OnEnable()
    {
        _masterVolumeSlider.Add(_masterVolumeChanger.ChangeVolume);
        _musicVolumeSlider.Add(_musicVolumeChanger.ChangeVolume);
        _effectsVolumeSlider.Add(_effectsVolumeChanger.ChangeVolume);

        _toggle.Add(ToggleVolume);
    }

    private void OnDisable()
    {
        _masterVolumeSlider.Remove(_masterVolumeChanger.ChangeVolume);
        _musicVolumeSlider.Remove(_musicVolumeChanger.ChangeVolume);
        _effectsVolumeSlider.Remove(_effectsVolumeChanger.ChangeVolume);

        _toggle.Remove(ToggleVolume);
    }

    private void ToggleVolume()
    {
        _enable = !_enable;

        if (_enable)
        {
            _audioMixer.SetFloat(MasterVolumeParameter, 0);
        }
        else
        {
            _audioMixer.SetFloat(MasterVolumeParameter, -80);
        }
    }
}