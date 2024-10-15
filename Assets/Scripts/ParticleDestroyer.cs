using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 1f;
    
    private void OnEnable() {
        transform.parent = null;
        Destroy(gameObject, _timeToDestroy);
    }
}
