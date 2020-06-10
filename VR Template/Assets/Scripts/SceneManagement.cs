﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string nextSceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
