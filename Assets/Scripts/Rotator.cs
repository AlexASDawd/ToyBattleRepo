using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 75f;
    void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
    }
}
