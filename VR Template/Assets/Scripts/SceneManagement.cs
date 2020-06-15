using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string playGameSceneName;
    public string lootBoxSceneName;
    public string mainMenuSceneName;

    public void PlayGameScene()
    {
        SceneManager.LoadScene(playGameSceneName);
    }

    public void LoadLootBoxScene()
    {
        SceneManager.LoadScene(lootBoxSceneName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
