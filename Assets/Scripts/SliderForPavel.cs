using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderForPavel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private InteractableObject[] _toys;

    private float _startForceValue = 1500;
    private float _forceAmount;
    public float ForceAmount {
        get { return _forceAmount; }
        set {
            _forceAmount = value;
            UpdateText();
            Debug.Log("awdawd");
        }
    }

    private void Start() {
        _slider.value = _startForceValue;
        UpdateText();
    }
    private void OnEnable() {
        _slider.onValueChanged.AddListener(OnSliderChanged);
    }
    private void OnSliderChanged(float value) {
        _forceAmount = value;
        UpdateText();
    }
    public void UpdateValues() {
        for (int i = 0; i < _toys.Length; i++) {
            _toys[i].UpdateForce(_forceAmount);
        }
    }

    private void UpdateText() {
        float newText = Mathf.Floor(_forceAmount);
        _text.text = newText.ToString();
    }
}
