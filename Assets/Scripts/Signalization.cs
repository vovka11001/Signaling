using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private static float _elapsedTime = 0.1f;
    private float _targetVolume; 
    private float _maxVolume = 1f;
    private float _fadeSpeed = 15f;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(_elapsedTime);
    private Coroutine _coroutine;

    public bool IsCounting { get; private set; }

    private void Start()
    {
        _audioSource.volume = 0f;
    }

    public void StartCountDown()
    {
        if (IsCounting)
            return;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        IsCounting = true;
        _coroutine = StartCoroutine(CountDown());
    }

    public void IncreaseVolume()
    {
        _targetVolume = _maxVolume;
    }

    public void DecreaseVolume()
    {
        _targetVolume = 0f;
    }

    private void TogleSignaling()
    {
        if (!_audioSource.isPlaying)
            _audioSource.Play();
        
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
        
        if (_audioSource.volume == 0f && _audioSource.isPlaying)
            _audioSource.Stop();
    }

    private IEnumerator CountDown()
    {
        while (IsCounting)
        {
            TogleSignaling();

            yield return _waitForSeconds;
        }
    }
}
