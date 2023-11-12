using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private Toggle _soundToggle;

    private bool _enabled = true;

    private void Start()
    {
        _soundToggle.onValueChanged.AddListener(UpdateSoundState);
    }

    public void PlayCollectedSound()
    {
        if(_enabled)
            _audioSource.PlayOneShot(_coinSound);
    }

    public void PauseSound()
    {
        _enabled = false;
        _audioSource.Pause();
    }

    public void ResumeSound()
    {        
        _enabled = true;
        _audioSource.UnPause();
    }

    private void UpdateSoundState(bool state)
    {
        if(state)
            ResumeSound();
        else
            PauseSound();
    }
}