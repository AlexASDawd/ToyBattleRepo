using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _sliderValue = 0;
    private float _sliderIncrement;

    private void Start() {
        UpdateSliderValue();
    }
    private void UpdateSliderValue() {
        _slider.value = _sliderValue;
    }

    public void AdjustSliderValue() {
        _sliderValue += _sliderIncrement;
        if(_sliderValue > 1) {

            _sliderValue = 1;
        }
        UpdateSliderValue();
    }

    public void CalculateIncrement(int toysCountCorrected) {
        _sliderIncrement = 1 / (float)toysCountCorrected;
    }
}
