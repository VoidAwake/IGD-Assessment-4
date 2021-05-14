using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private Transform target;

    private Vector3 basePosition;

    private void Start() {
        basePosition = transform.position;
    }
    
    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, basePosition.y, basePosition.z);
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
