using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject levelButton;

    private void Start() {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            if (i != 0) {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string levelName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                GameObject newButton = Instantiate(levelButton, canvas);
                newButton.name = levelName + " Button";
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(levelName));
                newButton.GetComponentInChildren<Text>().text = levelName;
            }
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
