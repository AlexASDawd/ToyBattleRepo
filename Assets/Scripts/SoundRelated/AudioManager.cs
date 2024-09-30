using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _collisionSources;
    [SerializeField] private float _pitchRange = 0.15f;

    [SerializeField] private AudioSource _interactSource;
    [SerializeField] private float _timeBeforeUnmute = 1f;

    private bool _isMuted = true;


    private void Start() {
        Invoke(nameof(UnMute), _timeBeforeUnmute);
    }
    public void PlayRandomCollisionSound() {
        if (!_isMuted) {
            AudioSource audioSource = _collisionSources[Random.Range(0, _collisionSources.Length)];
            audioSource.pitch = Random.Range(1 - _pitchRange, 1 + _pitchRange);
            audioSource.Play();
        }
    }

    public void PlayInteractionSound() {
        if (!_isMuted) {
            _interactSource.pitch = Random.Range(1 - _pitchRange, 1 + _pitchRange);
            _interactSource.Play();
        }
    }

    private void UnMute() {
        _interactSource.enabled = true;
        _isMuted = false; 
    }
}
