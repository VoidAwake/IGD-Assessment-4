using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject evidenceText;
    [SerializeField] private Vector2 textPadding;
    [SerializeField] private float verticalTextOffset;

    private bool notebookOpen = false;

    private List<GameObject> evidenceTexts = new List<GameObject>();

    private List<Evidence> selectedEvidence = new List<Evidence>();
    
    void Start()
    {
        mainPanel.SetActive(false);

        foreach (var evidence in PersistentData.FoundEvidence)
        {
            DisplayEvidence(evidence);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ToggleNotebook();
        }
    }

    private void ToggleNotebook()
    {
        notebookOpen = !notebookOpen;
        
        mainPanel.SetActive(notebookOpen);
    }

    public void AddEvidence(Evidence evidence)
    {
        if (PersistentData.FoundEvidence.Contains(evidence)) return;
            
        PersistentData.FoundEvidence.Add(evidence);

        DisplayEvidence(evidence);
    }

    public void DisplayEvidence(Evidence evidence) {
        foreach (var description in evidence.descriptions)
        {
            GameObject newEvidenceText = Instantiate(
                evidenceText,
                textPadding + Vector2.down * (evidenceTexts.Count * verticalTextOffset),
                Quaternion.identity
            );

            newEvidenceText.transform.SetParent(mainPanel.transform, false);
            
            evidenceTexts.Add(newEvidenceText);

            newEvidenceText.GetComponent<Text>().text = description;
        }
    }

    public void SelectEvidence (Evidence evidence) {
        if (selectedEvidence.Contains(evidence)) return;

        // ChangeColor

        if (selectedEvidence == null) {
            selectedEvidence = evidence;
        } else {
            CheckConnection(evidence, selectedEvidence);

            selectedEvidence = null;

            // ChangeColor
        }
    }

    public void CheckConnection (Evidence evidence1, Evidence evidence2) {
        // foreach (var connection in connections) {
           // if (connection.components.Contains(evidence1) && connection.components.Contains(evidence2)) {
               // AddEvidence(connection.evidence);
               //break;
           // }
       // }
    }
}
