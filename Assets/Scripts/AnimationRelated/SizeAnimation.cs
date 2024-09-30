using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAnimation : MonoBehaviour
{
    public AnimationCurve sizeCurve; // The curve controlling the size
    public float animationDuration = 2.0f; // Duration of the animation
    private Coroutine _animationCoroutine;

    public void TriggerSizeAnimation() {
        if (_animationCoroutine != null) {
            StopCoroutine(_animationCoroutine);
        }
        _animationCoroutine = StartCoroutine(AnimateSize());
    }

    // Coroutine that performs the size animation
    private IEnumerator AnimateSize() {
        float elapsedTime = 0.0f;

        while (elapsedTime < animationDuration) {
            // Calculate the normalized time (0 to 1)
            float normalizedTime = elapsedTime / animationDuration;

            // Get the size factor from the Animation Curve
            float sizeFactor = sizeCurve.Evaluate(normalizedTime);

            // Apply the new size to the object
            transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        // Ensure the final size is set
        transform.localScale = new Vector3(sizeCurve.Evaluate(1.0f), sizeCurve.Evaluate(1.0f), sizeCurve.Evaluate(1.0f));
    }
}
