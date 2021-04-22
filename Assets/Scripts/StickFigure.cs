using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickFigure : MonoBehaviour
{
    public void CollisionWithSpike()
    {
        SceneManager.LoadScene(0);
    }
}
