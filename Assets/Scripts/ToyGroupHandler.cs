using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyGroupHandler : MonoBehaviour
{
    [SerializeField] private int _difficultyCorrection = 0;
    [SerializeField] private SceneHandler _sceneHandler;
    [SerializeField] private SliderHandler _slider;
    private InteractableObject[] _toys;
    private int _toysCount;
    private int _groupIndex;

    private int _triggerCount = 0;

    private void Awake() {
        _sceneHandler = FindObjectOfType<SceneHandler>();
        _toys = GetComponentsInChildren<InteractableObject>();
        _toysCount = _toys.Length;
    }
    private void Start() {
        _groupIndex = _sceneHandler.AddToGroupList(this);
        _slider.CalculateIncrement(_toysCount - _difficultyCorrection);
    }
    public void AddOneToTriggerCount() {
        _triggerCount++;
        _slider.AdjustSliderValue();
        _sceneHandler.UpdateTriggerCount(_triggerCount, _groupIndex);
    }

    public void GetIndex(int index) {
        _groupIndex = index;
    }
}
