using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    
    public void OnClickButton()
    {
        _audio.Play();
    }
}