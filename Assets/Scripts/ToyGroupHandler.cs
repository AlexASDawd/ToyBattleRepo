using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyGroupHandler : MonoBehaviour
{
    [SerializeField] private float _difficultyPercent = 0.7f;
    [SerializeField] private SceneHandler _sceneHandler;
    [SerializeField] private NewSliderHandler _slider;

    
    [SerializeField] private int _requairedSceneIndex = 1;
    private InteractableObject[] _toys;
    private float _toysCount;
    private int _numberOfTriggersToWin;

    private int _triggerCount = 0;

    private void Awake() {
        _sceneHandler = FindObjectOfType<SceneHandler>();
        _toys = GetComponentsInChildren<InteractableObject>();
        if (_sceneHandler._isMenuScene) {
            foreach (var toy in _toys) {
                toy.SetMenuInteraction();
            }
        }
        _toysCount = _toys.Length;
    }
    private void Start() {
        _numberOfTriggersToWin = Mathf.RoundToInt(_toysCount * _difficultyPercent);

        if (_slider.isActiveAndEnabled) {
            _slider.CalculateIncrement(_numberOfTriggersToWin);
        }
    }
    public void AddOneToTriggerCount() {
        
        _triggerCount++;
        if (_slider.isActiveAndEnabled) {
            
            _slider.AdjustSliderValue();
        }
        if(_triggerCount >= _numberOfTriggersToWin) {

            _slider.ActivateAnimation();
            _sceneHandler.EndGame(0);
        }
    }

    public void ChangeScene() {
        _sceneHandler.EndGame(_requairedSceneIndex);
    }

}
