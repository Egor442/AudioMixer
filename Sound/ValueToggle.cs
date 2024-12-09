using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ValueToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private float _multiplier;

    private bool _enable = true;

    private Button _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _toggle.onClick.AddListener(ToggleVolume);
    }

    private void OnDisable()
    {
        _toggle.onClick.RemoveListener(ToggleVolume);
    }

    private void ToggleVolume()
    {
        _enable = !_enable;

        if (_enable)
        {
            _masterMixer.audioMixer.SetFloat(_masterMixer.name, 0);
        }
        else
        {
            _masterMixer.audioMixer.SetFloat(_masterMixer.name, -80);
        }
    }
}