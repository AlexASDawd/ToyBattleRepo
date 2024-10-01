using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _faderImage;
    public float FadeTime = 3f;
    private Coroutine _coroutine;

    void Start() {

        _coroutine = StartCoroutine(FadeTo(0f, FadeTime));
    }

    public IEnumerator FadeTo(float targetAlpha, float duration) {
        Color startColor = _faderImage.color;
        float startAlpha = startColor.a;

        float time = 0f;

        while (time < duration) {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            startColor.a = newAlpha;

            _faderImage.color = startColor;

            time += Time.deltaTime;
            yield return null;
        }

        startColor.a = targetAlpha;
        _faderImage.color = startColor;
    }
    
    public void FadeIn() {
        if (_coroutine != null) {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(FadeTo(1f, FadeTime));

    }
    public void FadeOut() {
        if (_coroutine != null) {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(FadeTo(0, FadeTime));
    }
}
