using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField] public StickFigure stickFigure;

    private void OnTriggerEnter2D(Collider2D other)
    {
        stickFigure.CollisionWithSpike();
    }
}
