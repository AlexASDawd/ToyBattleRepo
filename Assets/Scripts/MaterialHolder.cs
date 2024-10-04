using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour
{
    [SerializeField] private Material[] _materials;



    public Material GetRandomMaterial() {

        return _materials[Random.Range(0, _materials.Length)];
    }
}
