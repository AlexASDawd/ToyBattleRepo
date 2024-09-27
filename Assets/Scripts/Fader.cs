using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _faderImage;
    public float FadeTime = 3f;
    //private float _maxAlpha = 100;
    //private float _minAlpha = 0;
    //private float _currentAlpha;




    void Start() {
        StartCoroutine(FadeTo(0f, 2f));
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
        StartCoroutine(FadeTo(1f, 2));
    }

    public void FadeOut() {
        StartCoroutine(FadeTo(0, 2));
    }
}
