using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private string[] _winMessages;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable() {
        _text.text = _winMessages[Random.Range(0, _winMessages.Length)];
    }
}
