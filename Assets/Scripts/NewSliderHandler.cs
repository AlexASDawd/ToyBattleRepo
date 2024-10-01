using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewSliderHandler : MonoBehaviour {
    [SerializeField] private Slider _slider;
    private float _sliderValue = 0;
    private float _sliderIncrement;
    private Coroutine _sliderCoroutine;
    private float _sliderVelocity = 0.0f; // Velocity of the smooth damp operation
    [SerializeField]  private float _smoothTime = 0.2f; // Time it takes to smooth the value
    [SerializeField] private SizeAnimation _sliderAnimation;

    private void Start() {
        UpdateSliderValue();
    }

    private void UpdateSliderValue() {
        _slider.value = _sliderValue;
    }

    public void ActivateAnimation() {
        _sliderAnimation.TriggerSizeAnimation();
    }
    public void AdjustSliderValue() {
        _sliderValue += _sliderIncrement;

        // Clamp value between 0 and 1
        _sliderValue = Mathf.Clamp(_sliderValue, 0, 1);

        // Stop any existing coroutine
        if (_sliderCoroutine != null) {
            StopCoroutine(_sliderCoroutine);
        }

        // Start the smooth adjustment coroutine
        _sliderCoroutine = StartCoroutine(SmoothSliderAdjustment(_sliderValue));
    }

    public void CalculateIncrement(int toysCountCorrected) {
        // Prevent division by zero.
        _sliderIncrement = (toysCountCorrected > 0) ? 1 / (float)toysCountCorrected : 0;
    }

    private IEnumerator SmoothSliderAdjustment(float targetValue) {
        float currentValue = _slider.value; // Store the current slider value

        // Gradually update the slider value
        while (Mathf.Abs(currentValue - targetValue) > 0.01f) // Tolerance for stopping
        {
            currentValue = Mathf.SmoothDamp(currentValue, targetValue, ref _sliderVelocity, _smoothTime);
            _slider.value = currentValue;
            yield return null; // Wait for the next frame
        }

        // Ensure we set the slider value to the target value at the end
        _slider.value = targetValue;
    }
}
