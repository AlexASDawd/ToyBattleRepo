using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButtonsHandler : MonoBehaviour
{
    [SerializeField] private SizeAnimation[] _animations;

    private void OnEnable() {
        foreach (var animation in _animations) {
            animation.TriggerSizeAnimation();
        }
    }
}
