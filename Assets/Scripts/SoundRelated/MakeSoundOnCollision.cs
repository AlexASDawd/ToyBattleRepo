using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundOnCollision : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake() {
        _audioManager = GetComponent<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent(out Floor floor) ||
            collision.gameObject.TryGetComponent(out InteractableObject cube)) {
            _audioManager.PlayRandomCollisionSound();
        }
    }
}
