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

    private List<Evidence> evidences = new List<Evidence>();
    private List<GameObject> evidenceTexts = new List<GameObject>();
    
    void Start()
    {
        mainPanel.SetActive(false);
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
        if (evidences.Contains(evidence)) return;
            
        evidences.Add(evidence);

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
