using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Vector3 force;
    public Vector3 objectCurrentPosition;
    public Vector3 objectTargetPosition;
    public Vector3 gameObjectPoint;
    public Vector3 mousePreviousLocation;
    public Vector3 mouseCurrLocation;

    public float topSpeed = 10;

    private Rigidbody2D rb;
    private Vector3 offset;
    private bool isDragging = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            rb.velocity = force;
        }
    }

    private void OnMouseDown()
    {
        gameObjectPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        mousePreviousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectPoint.z);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectPoint.z));
    }

    private void OnMouseDrag()
    {
        mouseCurrLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectPoint.z);
        force = mouseCurrLocation - mousePreviousLocation;
        mousePreviousLocation = mouseCurrLocation;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(mouseCurrLocation) - offset;
        transform.position = curPosition;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        if (rb.velocity.magnitude > topSpeed)
            force = rb.velocity.normalized * topSpeed;

        isDragging = false;
    }
}