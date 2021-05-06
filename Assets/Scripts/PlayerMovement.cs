using System.Data.Common;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed;
    
    private new Camera camera;
    private Vector3 faceRightScale;
    private Vector3 faceLeftScale;

    public Vector3 targetPosition;
    public Interactable target;
    
    void Start()
    {
        camera = Camera.main;
        faceRightScale = transform.localScale;
        faceLeftScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z
        );
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePosition = Input.mousePosition;
        //
        //     targetPosition = camera.ScreenToWorldPoint(mousePosition);
        //
        //     targetPosition.z = 0;
        //     
        //     if (targetPosition.x > transform.position.x)
        //     {
        //         transform.localScale = faceRightScale;
        //     }
        //     else
        //     {
        //         transform.localScale = faceLeftScale;
        //     }
        // }

        if (Vector3.Distance(transform.position, targetPosition) > 0.2)
        {
            WalkAnimation();
            
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                movementSpeed * Time.deltaTime
            );
        }
        else
        {
            IdleAnimation();

            if (target != null)
            {
                target.Inspect();
                target = null;
            }
        }
    }

    private void WalkAnimation()
    {
        animator.SetTrigger("Walk");
    }

    private void IdleAnimation()
    {
        animator.SetTrigger("Idle");
    }

    public void SetTarget(Interactable interactable)
    {
        target = interactable;
        targetPosition = interactable.transform.position;
        
        if (targetPosition.x > transform.position.x)
        {
            transform.localScale = faceRightScale;
        }
        else
        {
            transform.localScale = faceLeftScale;
        }
    }
}
