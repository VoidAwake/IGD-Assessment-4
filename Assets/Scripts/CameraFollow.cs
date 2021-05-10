using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 setPosition = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, setPosition, smoothSpeed);
        transform.position = setPosition;
    }
}
