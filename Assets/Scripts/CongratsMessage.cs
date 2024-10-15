using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CongratsMessage : MonoBehaviour {
    [SerializeField] private GameObject[] _effectsToActivate;

    [SerializeField] private GameObject[] _constantEffects;

    [SerializeField] private float _minSpawnTime = 0.2f;
    [SerializeField] private float _maxSpawnTime = 0.9f;
    [SerializeField] private Transform[] _spawnTransforms;
    [SerializeField] private bool _sequenceIsActive = false;

    public UnityEvent OnSequenceStarting;

    private Coroutine _currentCoroutine;

    private void OnDestroy() {
        StopAllCoroutines();
    }

    public void StartSequence() {
        OnSequenceStarting.Invoke();
        _sequenceIsActive = true;
        foreach (var effectToActivate in _effectsToActivate) {
            effectToActivate.SetActive(true);
        }

        if (_currentCoroutine != null) {
            StopCoroutine(_currentCoroutine);
        }

        StartCoroutine(nameof(ConstantEffectsHandle));
    }
    private IEnumerator ConstantEffectsHandle() {

        while (_sequenceIsActive) {
            GameObject effect = Instantiate(_constantEffects[Random.Range(0, _constantEffects.Length)],
                    _spawnTransforms[Random.Range(0, _spawnTransforms.Length)].position,
                    Quaternion.identity);
            effect.AddComponent<ParticleDestroyer>();

            yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
        }
    }

    public void StopSequence() {
        foreach (var _effectToDeactivate in _effectsToActivate) {
            _effectToDeactivate.SetActive(false);
        }

        _sequenceIsActive = false;
    }
}
