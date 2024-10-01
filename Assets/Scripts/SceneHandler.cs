using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private List<ToyGroupHandler> _toyGroups;
    [SerializeField] private Fader _fader;
    [SerializeField] private int _sceneToLoad = 1;
    [SerializeField] private AudioSource _winSound;
    public bool _isMenuScene = false;
    private bool _gameIsEnded = false;
    public void LoadSceneHandler() {
        _fader.FadeIn();
        Invoke(nameof(LoadScene), _fader.FadeTime);
    }
    private void LoadScene() {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void Quit() {
        Application.Quit();
    }

    public void EndGame(int sceneIndex) {
        if (!_gameIsEnded) {

            _winSound.Play();
            Debug.Log("LoadingScene");
            _sceneToLoad = sceneIndex;
            _gameIsEnded = true;
            LoadSceneHandler();
        }
    }

}
