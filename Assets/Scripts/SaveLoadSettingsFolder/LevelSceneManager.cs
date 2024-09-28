using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneManager : MonoBehaviour
{
    public SaveLoadSettings SaveLoadSettings;
    private int _mode;
    void Start()
    {
        SaveLoadSettings.LoadData();

        _mode = SaveLoadSettings.getDataIntById(0);
        if(_mode == 0) {
            //Your GameMode
        }
    }

}
