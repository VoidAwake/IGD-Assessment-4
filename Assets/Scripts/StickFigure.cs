using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StickFigure : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    private void Start()
    {
        UpdateScoreText();
        UpdateHighscoreText();
    }

    private void Update()
    {
        UpdateScoreText();
    }
    
    public void CollisionWithSpike()
    {
        if (Time.timeSinceLevelLoad > GetHighscore())
        {
            SaveHighscore(Time.timeSinceLevelLoad);
        }
        SceneManager.LoadScene(0);
    }
    
    private float GetHighscore()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            SaveHighscore(0);
        }

        return PlayerPrefs.GetFloat("highscore");
    }

    private void SaveHighscore(float value)
    {
        PlayerPrefs.SetFloat("highscore", value);
        PlayerPrefs.Save();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + Time.timeSinceLevelLoad.ToString("F2");
    }
    
    private void UpdateHighscoreText()
    {
        highscoreText.text = "Highscore: " + GetHighscore().ToString("F2");
    }
}