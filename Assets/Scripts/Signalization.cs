using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private float _targetVolume; 
    private float _maxVolume = 1f;
    private float _fadeSpeed = 1f;
    
    private void Start()
    {
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        StartSignaling();
    }
    
    public void IncreaseVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void DecreaseVolume()
    {
        _targetVolume = 0f;
    }

    private void StartSignaling()
    {
        if (!_audioSource.isPlaying)
            _audioSource.Play();
        
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
        
        if (_audioSource.volume == 0f && _audioSource.isPlaying)
            _audioSource.Stop();
    }
}
