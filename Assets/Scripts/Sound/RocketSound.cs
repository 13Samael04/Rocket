using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class RocketSound : MonoBehaviour
{
    [SerializeField] private AudioClip _deadSound;
    [SerializeField] private AudioClip _flySound;
    [SerializeField] private PlayerMovable _playerMovable;
    [SerializeField] private Player _player;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _playerMovable.Flew += OnFlyed;
        _player.Died += OnDied;
        _playerMovable.EngineShutDown += OnEngineOff;
    }

    private void OnDisable()
    {
        _playerMovable.Flew -= OnFlyed;
        _player.Died -= OnDied;
        _playerMovable.EngineShutDown -= OnEngineOff;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnFlyed()
    {
        if(_audioSource.isPlaying == false)
        {
            _audioSource.PlayOneShot(_flySound);
        }
    }

    public void OnEngineOff()
    {
        _audioSource.Stop();
    }

    public void OnDied()
    {
        _audioSource.Play();
        _audioSource.PlayOneShot(_deadSound);
    }
}
