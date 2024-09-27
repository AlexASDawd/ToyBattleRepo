using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    
    [SerializeField] private Gesture _gesture;
    [SerializeField] private float _forceMultiplier = 1f;
    [SerializeField] private ParticleSystem _interactEffect;
    [SerializeField] private Vector3 _offsetVector;
    [SerializeField] private float _interactionDelay = 0.05f;

    private ToyGroupHandler _parentToyGroup;
    private float _timeSinceLastInteraction = 0;
    private Vector3 _forceVector = Vector3.forward;
    
    private Rigidbody _rb;

    private bool _isInteracting = false;
    private bool _isTriggered = false;

    private void OnEnable() {
        _gesture.StateChanged += InteractionHandler;
    }

    private void OnDisable() {
        _gesture.StateChanged -= InteractionHandler;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _parentToyGroup = GetComponentInParent<ToyGroupHandler>();
    }

    private void Update() {
        _timeSinceLastInteraction += Time.deltaTime;
    }

    private void FixedUpdate() {
        if (_isInteracting) {
            _rb.AddForce(_forceVector * _forceMultiplier, ForceMode.Force);
            _isInteracting = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!_isTriggered && other.TryGetComponent(out ToyTrigger toyTrigger)){
            _parentToyGroup.AddOneToTriggerCount();
            _isTriggered = true;
        }
    }
    public void Interact() {
        Instantiate(_interactEffect, transform);
        _isInteracting = true;
    }

    public void InteractionHandler(object sender, GestureStateChangeEventArgs e) {
        if(_timeSinceLastInteraction > _interactionDelay) {
            Interact();
            _timeSinceLastInteraction = 0;
        }
    }

    public void UpdateForce(float value) {
        _forceMultiplier = value;
    }

    
}
