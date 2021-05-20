using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public static float deltaTime;
    public static float timeScale = 1.0f;
    public static float playTime = 0;
    private float endTime = 55;

    private bool walking;

    private Vector3 faceRightScale;
    private Vector3 faceLeftScale;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0, -0.3f, 0);
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
        deltaTime = Time.deltaTime * timeScale;
        playTime += deltaTime;
        timeScale = ((timeScale < 0 && playTime <= 0) || (timeScale > 0 && playTime >= endTime)) ? 0 : timeScale; //Pause video if it reaches start/end

        if (playTime >= endTime)
        {
            //DO SOMETHING ONCE VIDEO ENDS
        }

        animator.enabled = (timeScale != 0) ? true : false;
        animator.SetTrigger((walking) ? ((timeScale > 0) ? "Walk" : "Reverse") : "Idle");

        if (playTime > 1 && playTime < 2.1f || // Walk Right
            playTime > 17.1f && playTime < 21.1f ||
            playTime > 39 && playTime < 42 ||
            playTime > 47 && playTime < 50)
        {
            walking = true;
            gameObject.transform.localScale = faceRightScale;
            gameObject.transform.position += new Vector3(2.5f, 0, 0) * deltaTime;
        }
        if (playTime > 2.1f && playTime < 7.1f || // Idle
            playTime > 21.1f && playTime < 39 || 
            playTime > 42 && playTime < 44 ||
            playTime > 50 && playTime < 51)
        {
            walking = false;
        }
        if (playTime > 7.1f && playTime < 11.1f || // Walk Left
            playTime > 33 && playTime < 37 ||
            playTime > 44 && playTime < 47)
        {
            walking = true;
            gameObject.transform.localScale = faceLeftScale;
            gameObject.transform.position += new Vector3(-2.5f, 0, 0) * deltaTime;
        }

        if (playTime > -0.1f && playTime < 1 || // Off screen times
            playTime > 11.1f && playTime < 17.1f ||
            playTime > 37 && playTime < 39 ||
            playTime > 51)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        Debug.Log(playTime);
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