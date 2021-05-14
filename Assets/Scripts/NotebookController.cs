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
    
    void Start()
    {
        mainPanel.SetActive(false);

        Debug.Log(PersistentData.FoundEvidence.Count);

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
}
