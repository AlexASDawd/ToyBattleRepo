using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyGroupHandler : MonoBehaviour
{
    [SerializeField] private int _difficultyCorrection = 0;
    [SerializeField] private SceneHandler _sceneHandler;
    [SerializeField] private NewSliderHandler _slider;
    private InteractableObject[] _toys;
    private int _toysCount;
    private int _numberOfTriggersToWin;

    private int _triggerCount = 0;

    private void Awake() {
        _sceneHandler = FindObjectOfType<SceneHandler>();
        _toys = GetComponentsInChildren<InteractableObject>();
        _toysCount = _toys.Length;
    }
    private void Start() {
        _numberOfTriggersToWin = _toysCount - _difficultyCorrection;

        //if(_slider != null) {
        //    _slider.CalculateIncrement(_toysCount - _difficultyCorrection);
        //}

        if (_slider) {
            _slider.CalculateIncrement(_numberOfTriggersToWin);
        }
    }
    public void AddOneToTriggerCount() {
        _triggerCount++;
        if (_slider) {
            _slider.AdjustSliderValue();
        }
    }
}
