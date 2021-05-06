using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 worldPosition = camera.ScreenToWorldPoint(mousePosition);

            worldPosition.z = 0;

            transform.DOMove(worldPosition, 2);
        }
    }
}
