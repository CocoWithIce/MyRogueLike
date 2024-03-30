using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager: MonoBehaviour
{
    public SceneManager SceneManager;
    public ConfigManager ConfigManager;

    #region StartScene
    public void OnStart()
    {
        Debug.Log("Start is Clicked");
    }

    public void OnSettings()
    {
        Debug.Log("Settings is Clicked");
    }
    public void OnQuit()
    {
        Debug.Log("Quit is Clicked");
        //Save current game;
        //Application.Quit();
    }
    #endregion

}
