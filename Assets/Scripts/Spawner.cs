using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeBeforeDestroy;


    private void Start() {
        Invoke(nameof(SpawnPrefab), 4f);
    }

    private void SpawnPrefab() {
        GameObject currentPrefab = Instantiate(_prefab, transform.position, transform.rotation);
        Destroy(currentPrefab, _timeBeforeDestroy);
    }

}
