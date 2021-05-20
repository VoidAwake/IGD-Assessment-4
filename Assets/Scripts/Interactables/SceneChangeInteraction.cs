using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneChangeInteraction : Interactable
    {
        [SerializeField] private int sceneBuildIndex;

        public override void Interact()
        {
            PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(sceneBuildIndex);

            // Debug.Log(PersistentData.LastPosition);

            // PersistentData.LastPosition = transform;

            // Debug.Log(PersistentData.LastPosition);
        }
    }
}