using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    private MaterialHolder _materialHolder;
    private GameObject _childObject;
    private Material _materialForChildObject;

    private void Awake() {
        _materialHolder = FindObjectOfType<MaterialHolder>();
        _childObject = transform.GetChild(0).gameObject;
        _materialForChildObject = _materialHolder.GetRandomMaterial();


    }
    private void Start() {
        if(_childObject.TryGetComponent(out Renderer renderer)) {
            renderer.material = _materialForChildObject;
        } else {
            _childObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = _materialForChildObject;
        }
    }
}
