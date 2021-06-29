using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickItem : MonoBehaviour
{
    private bool selected = false;
    private GameObject selectedObject;

    void Start()
    {

    }

    void Update()
    {
        // //Debug.Log(Time.timeScale);
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert clicked location to screen coordinates
        //     Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //convert coordinates to 2d

        //     RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero); //cast a ray only at that point
        //     if (hit.collider != null) //if something was detected
        //     {
        //         selectedObject = hit.collider.gameObject;
        //         Debug.Log(selectedObject.name);
        //         Video.timeScale = (selectedObject.CompareTag("Play")) ? 1.0f :
        //             selectedObject.CompareTag("Pause") ? 0.0f :
        //             selectedObject.CompareTag("Rewind") ? -1.0f :
        //             Video.timeScale;
        //         if (selectedObject.CompareTag("Exit"))
        //         {

        //         }
        //     }
        // }
    }

    public void Exit () {
        PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(4);
    }

    public void Rewind () {
        Video.timeScale = -1;
    }

    public void Pause () {
        Video.timeScale = 0;
    }

    public void Play () {
        if (Video.timeScale < 4) {
            Video.timeScale += 1;
        }
    }
}