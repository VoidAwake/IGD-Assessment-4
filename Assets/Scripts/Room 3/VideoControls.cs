using UnityEngine;

public class VideoControls : MonoBehaviour
{
    public void Exit () {
        Camera.main.GetComponent<SceneTransition>().ExitScene(4, false);
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