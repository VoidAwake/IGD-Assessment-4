using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject lossDisplay;
    [SerializeField] private GameObject winDisplay;

    public void AccuseProfessorPlum() {
        winDisplay.SetActive(true);
    }

    public void AccuseColonelMustard() {
        lossDisplay.SetActive(true);
    }
}
