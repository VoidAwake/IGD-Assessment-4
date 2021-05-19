using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float deltaTime;
    public static float timeScale = 1.0f;
    public static float playTime = 0;
    private float endTime = 13;

    private bool walking;

    private Vector3 faceRightScale;
    private Vector3 faceLeftScale;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(-5, -0.5f, 0);
        faceRightScale = transform.localScale;
        faceLeftScale = new Vector3(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        WalkAnimation();
        deltaTime = Time.deltaTime * timeScale;
        playTime += deltaTime;

        animator.enabled = (timeScale != 0) ? true : false;
        animator.SetTrigger((timeScale > 0) ? "Walk" : "Reverse");
        animator.SetTrigger((walking) ? ((timeScale > 0) ? "Walk" : "Reverse") : "Idle");

        timeScale = ((timeScale < 0 && playTime <= 0) || (timeScale > 0 && playTime >= endTime)) ? 0 : timeScale; //Pause video if it reaches start/end

        if (playTime > 0 && playTime < 4) //Walking to the office
        {
            walking = true;
            gameObject.transform.localScale = faceRightScale;
            gameObject.transform.position += new Vector3(2.5f, 0, 0) * deltaTime;
        }
        else if (playTime > 6 && playTime < 10) //Walking away from the office
        {
            walking = true;
            gameObject.transform.localScale = faceLeftScale;
            gameObject.transform.position += new Vector3(-2.5f, 0, 0) * deltaTime;
        }

        if ((playTime > 4 && playTime < 6) || //Off screen times
            (playTime > 12))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
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

    private void ReverseAnimation()
    {
        animator.SetTrigger("Reverse");
    }
}