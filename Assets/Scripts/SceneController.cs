using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
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
}
