using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int highScoreCount;
    public int HighScoreCount
    {
        get
        {
            return highScoreCount;
        }
        set
        {
            if (value > 0)
            {
                highScoreCount = value;
            }
        }
    }
    [SerializeField] Text highScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            HighScoreCount = PlayerPrefs.GetInt("SaveScore");
            highScore.text = HighScoreCount.ToString() + " points";
        }
    }
    public static bool AddHighScore(int currScore)
    {
        int highScoreCount = PlayerPrefs.GetInt("SaveScore");
        if (currScore > highScoreCount)
        {
            highScoreCount = currScore;
            PlayerPrefs.SetInt("SaveScore", highScoreCount);
        }
        return currScore == highScoreCount;
    }
}
