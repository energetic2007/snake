using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject InfoPanel;
    public static int previousSceneIndex;
    public void Select(int numberInBuild)
    {
        int currentLevel = numberInBuild;
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        if (levelReached < currentLevel) PlayerPrefs.SetInt("levelReached", currentLevel);
        SceneManager.LoadScene(numberInBuild);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        InfoPanel.SetActive(true);
    }
    public void Restime()
    {
        Time.timeScale = 1;
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
