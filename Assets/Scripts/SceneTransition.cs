using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private float sceneTransitionSpeed;
    [SerializeField] private Image blockerPanel;
    [SerializeField] private float blockerTiming;
    
    void Start()
    {
        if (PersistentData.FirstLoad)
            PersistentData.FirstLoad = false;
        else
            EnterScene();
    }

    private void EnterScene()
    {
        StartCoroutine(EnterSceneTransition());
    }
    
    public void ExitScene(int sceneBuildIndex, bool transition)
    {
        PersistentData.PreviousScene = SceneManager.GetActiveScene().buildIndex;
        
        if (transition)
            StartCoroutine(ExitSceneTransition(sceneBuildIndex));
        else
            SceneManager.LoadScene(sceneBuildIndex);
    }

    private IEnumerator EnterSceneTransition()
    {
        blockerPanel.enabled = true;
        
        blockerPanel.color = Color.black;
        
        cameraFollow.MoveToTarget();
        
        cameraFollow.enabled = false;
        
        var rotationPoint = new Vector3(
            transform.position.x,
            transform.position.y,
            0
        );
        
        transform.RotateAround(rotationPoint, Vector3.up, -90);
        
        while (Vector3.Angle(transform.forward, Vector3.forward) > 1)
        {
            transform.RotateAround(rotationPoint, Vector3.up, sceneTransitionSpeed * Time.deltaTime);

            float ratio = Vector3.Angle(transform.forward, Vector3.forward) / 90 * blockerTiming - blockerTiming + 1;
            
            blockerPanel.color = Color.Lerp(Color.clear, Color.black, ratio);
                
            yield return null;
        }

        blockerPanel.color = Color.clear;

        blockerPanel.enabled = false;
        transform.rotation = Quaternion.identity;
        
        cameraFollow.MoveToTarget();
        
        cameraFollow.enabled = true;
    }

    private IEnumerator ExitSceneTransition(int sceneBuildIndex)
    {
        cameraFollow.enabled = false;
        
        blockerPanel.enabled = true;
        
            
        var rotationPoint = new Vector3(
            transform.position.x,
            transform.position.y,
            0
        );
            
        while (Vector3.Angle(transform.forward, Vector3.forward) < 90)
        {
            transform.RotateAround(rotationPoint, Vector3.up, sceneTransitionSpeed * Time.deltaTime);
            
            float ratio = (1 - Vector3.Angle(transform.forward, Vector3.forward) / 90) * 3;
            
            blockerPanel.color = Color.Lerp(Color.clear, Color.black, 1 - ratio);
                
            yield return null;
        }

        blockerPanel.color = Color.black;
            
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
