using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;

    private void Start() {
        InstantiateRandom();
    }
    private void InstantiateRandom() {
        GameObject group = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position, transform.rotation, transform);
    }
}
