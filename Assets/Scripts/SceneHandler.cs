using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private List<ToyGroupHandler> _toyGroups;
    [SerializeField] private Fader _fader;
    private int _toyCollisionsNumber = 0;
    public void UpdateTriggerCount(int collisionsCount, int groupIndex) {
        _toyCollisionsNumber = collisionsCount;
    }

    public int AddToGroupList(ToyGroupHandler toyGroup) {
        int indexToSend;
        if (_toyGroups.Count > 0) {
            indexToSend = 1;
        }else {
            indexToSend = 0;
        }
        _toyGroups.Add(toyGroup);
        return indexToSend;
    }

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
