using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    private void Start()
    {
        if (!PersistentData.OpenedScenes.Contains(SceneManager.GetActiveScene().buildIndex))
            PersistentData.OpenedScenes.Add(SceneManager.GetActiveScene().buildIndex);
    }
}
