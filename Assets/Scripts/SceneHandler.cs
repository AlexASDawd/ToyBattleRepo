using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private List<ToyGroupHandler> _toyGroups;
    [SerializeField] private Fader _fader;
    

    public void ReloalSceneHandler() {
        _fader.FadeIn();
        Invoke(nameof(ReloadScene), _fader.FadeTime);
    }
    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
    }

}
