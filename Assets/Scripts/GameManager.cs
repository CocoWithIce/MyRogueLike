using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager: MonoBehaviour
{
    [FormerlySerializedAs("SceneManager")] public GameSceneManager gameSceneManager;
    public ConfigManager ConfigManager;

    #region StartScene
    public void OnStart()
    {
        Debug.Log("Start is Clicked");
        gameSceneManager.LoadScene("Home");
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
