using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(-7.2f, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Video.playTime > 47 && Video.playTime < 50)
        {
            gameObject.transform.position += new Vector3(2.5f, 0, 0) * Video.deltaTime;
        }
        if (Video.playTime > 51)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
