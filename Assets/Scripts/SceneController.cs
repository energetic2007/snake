using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject InfoPanel;
    public static int previousSceneIndex;
    public void Select(int numberInBuild)
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        if (levelReached < numberInBuild) PlayerPrefs.SetInt("levelReached", numberInBuild);
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
        if(Input.touchCount > 0)
        {
            Restime();
        }
    }
    public void Restime()
    {
        Time.timeScale = 1;
        InfoPanel.SetActive(false);
    }
    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }
}
