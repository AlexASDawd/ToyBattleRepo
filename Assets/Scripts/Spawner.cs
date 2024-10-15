using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeBeforeDestroy = 6f;
    [SerializeField] private float _timeBeforeSpawn = 4f;


    private void Start() {
        Invoke(nameof(SpawnPrefab), _timeBeforeSpawn);
    }

    private void SpawnPrefab() {
        GameObject currentPrefab = Instantiate(_prefab, transform.position, transform.rotation);
        Destroy(currentPrefab, _timeBeforeDestroy);
    }

    //private void DestroyHandler(GameObject currentPrefab) {
    //    Destroy(currentPrefab, _timeBeforeDestroy);
    //}
}
