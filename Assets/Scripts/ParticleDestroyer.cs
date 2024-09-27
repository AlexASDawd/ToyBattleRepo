using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    private void OnEnable() {
        transform.parent = null;
        Destroy(gameObject, 1f);
    }
}
