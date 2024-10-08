using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    [SerializeField] private bool _isMenuChar = false;
    private MaterialHolder _materialHolder;
    private GameObject _object;
    private Material _materialForChildObject;

    private void Awake() {
        _materialHolder = FindObjectOfType<MaterialHolder>();
        if (_isMenuChar) {
            _object = transform.gameObject;
        } else {
            _object = transform.GetChild(0).gameObject;
        }
        
        _materialForChildObject = _materialHolder.GetRandomMaterial();


    }
    private void Start() {
        if(_object.TryGetComponent(out Renderer renderer)) {
            renderer.material = _materialForChildObject;
        } else {
            _object.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = _materialForChildObject;
        }
    }
}
