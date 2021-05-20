using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneChangeInteraction : Interactable
    {
        [SerializeField] private int sceneBuildIndex;

        protected override void Interact()
        {
            PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(sceneBuildIndex);
            Video.timeScale = 1.0f;
            Video.playTime = 0;
            GameObject.FindWithTag("N3").transform.position = new Vector3(0, -0.3f, 0);
        }
    }
}