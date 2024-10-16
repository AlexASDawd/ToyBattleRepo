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

    [SerializeField] private GameObject _sceneChangeButtons;

    [SerializeField] private int _timeBeforeChangeScene = 3;

    [SerializeField] private CongratsMessage _congratsMessage;

    public bool canShowMessage = true;

    //public bool _isMenuScene = false;
    private bool _gameIsEnded = false;
    public void LoadSceneHandler(int index) {
        _sceneToLoad = index;
        _fader.FadeIn();
        Invoke(nameof(LoadScene), _fader.FadeTime);
    }
    private void LoadScene() {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void Quit() {
        Application.Quit();
    }

    public void EndGame() {
        if (!_gameIsEnded) {

            if (_congratsMessage != null) {
                _congratsMessage.StartSequence();
            }

            _winSound.Play();

            _gameIsEnded = true;
            Invoke(nameof(ActivateSceneChangeButtons), 4f);
            //Invoke(nameof(LoadSceneHandler), _timeBeforeChangeScene);
        }
    }

    private void ActivateSceneChangeButtons() {
        _sceneChangeButtons.SetActive(true);
    }

}
