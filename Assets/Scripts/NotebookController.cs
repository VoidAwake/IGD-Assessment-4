using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject evidencePieceText;
    [SerializeField] private Vector2 textPadding;
    [SerializeField] private float verticalTextOffset;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color matchColor;
    [SerializeField] private Color noMatchColor;
    [SerializeField] private float colorFadeTime;
    [SerializeField] private List<Connection> connections = new List<Connection>();


    private bool notebookOpen = false;

    private Dictionary<EvidencePiece, GameObject> evidencePieceTexts = new Dictionary<EvidencePiece, GameObject>();

    private EvidencePiece selectedEvidencePiece;

    
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
        foreach (var evidencePiece in evidence.evidencePieces)
        {
            DisplayEvidencePiece(evidencePiece);
        }
    }

    public void DisplayEvidencePiece(EvidencePiece evidencePiece)
    {
        GameObject newEvidenceText = Instantiate(
            evidencePieceText,
            textPadding + Vector2.down * (evidencePieceTexts.Count * verticalTextOffset),
            Quaternion.identity
        );

        newEvidenceText.transform.SetParent(mainPanel.transform, false);
            
        evidencePieceTexts.Add(evidencePiece, newEvidenceText);

        newEvidenceText.GetComponent<Text>().text = evidencePiece.description;
            
        newEvidenceText.GetComponent<Button>().onClick.AddListener(() => SelectEvidence(evidencePiece));
    }

    public void SelectEvidence (EvidencePiece evidencePiece) {
        
        if (selectedEvidencePiece == evidencePiece) return;
        
        evidencePieceTexts[evidencePiece].GetComponent<Text>().color = selectedColor;
        
        if (selectedEvidencePiece == null) {
            selectedEvidencePiece = evidencePiece;
        } else
        {
            var newEvidencePiece = CheckConnection(evidencePiece, selectedEvidencePiece);
            
            if (newEvidencePiece != null)
            {
                evidencePieceTexts[evidencePiece].GetComponent<Text>().color = matchColor;
                evidencePieceTexts[selectedEvidencePiece ].GetComponent<Text>().color = matchColor;
                evidencePieceTexts[newEvidencePiece].GetComponent<Text>().color = matchColor;

                evidencePieceTexts[evidencePiece].GetComponent<Text>().DOColor(defaultColor, colorFadeTime);
                evidencePieceTexts[selectedEvidencePiece ].GetComponent<Text>().DOColor(defaultColor, colorFadeTime);
                evidencePieceTexts[newEvidencePiece].GetComponent<Text>().DOColor(defaultColor, colorFadeTime);
            }
            else
            {
                evidencePieceTexts[evidencePiece].GetComponent<Text>().color = noMatchColor;
                evidencePieceTexts[selectedEvidencePiece ].GetComponent<Text>().color = noMatchColor;
                
                evidencePieceTexts[evidencePiece].GetComponent<Text>().DOColor(defaultColor, colorFadeTime);
                evidencePieceTexts[selectedEvidencePiece ].GetComponent<Text>().DOColor(defaultColor, colorFadeTime);
            }
        
            selectedEvidencePiece = null;
        }
    }
    
    public EvidencePiece CheckConnection (EvidencePiece evidence1, EvidencePiece evidence2) {
        foreach (var connection in connections) {
            if (connection.components.Contains(evidence1) && connection.components.Contains(evidence2))
            {
                DisplayEvidencePiece(connection.evidencePiece);

                return connection.evidencePiece;
            }
        }
        
        return null;
    }
}
