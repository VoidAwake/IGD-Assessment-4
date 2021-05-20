using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoBackToMenu);
    }

    private void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
