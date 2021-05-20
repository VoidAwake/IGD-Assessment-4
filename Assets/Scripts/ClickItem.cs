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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert clicked location to screen coordinates
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //convert coordinates to 2d

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero); //cast a ray only at that point
            if (hit.collider != null) //if something was detected
            {
                selectedObject = hit.collider.gameObject;
                Video.timeScale = (selectedObject.CompareTag("Play")) ? (Video.timeScale == 1.0f) ? 3.0f : 1.0f :
                    selectedObject.CompareTag("Pause") ? 0.0f :
                    selectedObject.CompareTag("Rewind") ? (Video.timeScale == -1.0f) ? -3.0f : -1.0f :
                    Video.timeScale;
                if (selectedObject.CompareTag("Exit"))
                {
                    PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
                    SceneManager.LoadScene(4);
                }
            }
        }
    }
}