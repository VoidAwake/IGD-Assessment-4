using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    [SerializeField] private Text levelNameText;

    private string levelName;

    private void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
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
        Time.timeScale = enabled ? 0 : 1;
        
        overlay.SetActive(enabled);
    }
}
