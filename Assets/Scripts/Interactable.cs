using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private PlayerMovement player;
    
    private void OnMouseDown()
    {
        player.SetTarget(this);
    }

    public void Inspect()
    {
        Debug.Log(message);
    }
}
