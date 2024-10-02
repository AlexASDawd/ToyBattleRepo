using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public SaveLoadSettings SaveLoadSettings;
    private int _mode;
    void Start()
    {
        SaveLoadSettings.LoadData();

        _mode = SaveLoadSettings.getDataIntById(0);
        if(_mode == 0) {
            SceneManager.LoadScene(1);
        }
        else if(_mode == 1) {
            SceneManager.LoadScene(2);
        }
    }

}
