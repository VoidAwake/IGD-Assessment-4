using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Vector3 faceRightScale;
    private Vector3 faceLeftScale;

    void Start()
    {
        faceRightScale = transform.localScale;
        faceLeftScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z
        );
    }

    public void WalkAnimation(string direction)
    {
        if (direction == "right")
        {
            transform.localScale = faceRightScale;
        }
        else
        {
            transform.localScale = faceLeftScale;
        }

        animator.SetTrigger("Walk");
    }

    public void IdleAnimation()
    {
        animator.SetTrigger("Idle");
    }
}
