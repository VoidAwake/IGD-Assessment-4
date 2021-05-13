using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    private float deltaTime;
    public static float timeScale = 1.0f;
    private float playTime = 0;
    private float endTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(-5, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime * timeScale;
        playTime += deltaTime;
        gameObject.transform.position += new Vector3(2.5f, -0, 0) * deltaTime;
        timeScale = ((timeScale < 0 && playTime <= 0) || (timeScale > 0 && playTime >= endTime)) ? 0 : timeScale;
    }
}
