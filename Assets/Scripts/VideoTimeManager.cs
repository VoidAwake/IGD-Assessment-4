using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoTimeManager : MonoBehaviour
{
    private float time = 0;
    public static Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.FindWithTag("Time").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time = Video.playTime * 10 + 650;
        timeText.text = TimeFormat(time);
        //Debug.Log(TimeFormat(time));
    }
    public string TimeFormat(float time)
    {
        int hours = (int)time / 60;
        int minutes = (int)time % 60;
        return (string.Format("{0:00}:{1:00}", (time > 780)? hours - 12 : hours, minutes) + ((time < 720) ? "AM" : "PM"));
    }
}
