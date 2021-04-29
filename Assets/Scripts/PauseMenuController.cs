using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject overlay;
    [SerializeField] private Text levelNameText;

    private void Start()
    {
        levelNameText.text = levelName;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelName);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DisplayOverlay(bool enabled)
    {
        Time.timeScale = enabled ? 1 : 0;
        
        overlay.SetActive(enabled);
    }
}
