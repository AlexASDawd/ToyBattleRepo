using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    
    [SerializeField] private Gesture _gesture;
    [SerializeField] private float _forceMultiplier = 3000f;
    [SerializeField] private ParticleSystem _interactEffect;
    [SerializeField] private float _interactionDelay = 0.05f;

    private delegate void InteractionDelegate();
    private InteractionDelegate _interaction;

    private AudioManager _audioManager;
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
        if (_interaction == null) {
            _interaction = RegularInteraction;
        }
        _audioManager = GetComponent<AudioManager>();
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
    private void Interact() {
        Instantiate(_interactEffect, transform);
        _audioManager.PlayInteractionSound();
        _isInteracting = true;
    }


    private void RegularInteraction() {
        Interact();
        Debug.Log("RegularInteratcion");
    }

    private void MenuInteraction() {
        Interact();
        _parentToyGroup.ChangeScene();
        Debug.Log("MenuInteratcion");
    }
    public void InteractionHandler(object sender, GestureStateChangeEventArgs e) {
        if(_timeSinceLastInteraction > _interactionDelay) {
            _interaction?.Invoke();
            _timeSinceLastInteraction = 0;
        }
    }

    public void SetMenuInteraction() {
        _interaction = MenuInteraction;
    }

    
}
