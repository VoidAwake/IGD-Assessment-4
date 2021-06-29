using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoControls : MonoBehaviour
{
    public void Exit () {
        PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(4);
    }

    public void Rewind () {
        Video.timeScale = -1;
    }

    public void Pause () {
        Video.timeScale = 0;
    }

    public void Play () {
        if (Video.timeScale < 4) {
            Video.timeScale += 1;
        }
    }
}