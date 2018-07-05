﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float autoLoadafter;
  
    private void Start()
    {
        Invoke("LoadNextLevel", autoLoadafter);
    }
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        int currentSceenIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceenIndex + 1);
    }

 





}