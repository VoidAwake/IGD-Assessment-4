using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public static class PersistentData
{
    public static List<Evidence> FoundEvidence { get; } = new List<Evidence>();
    
    public static Transform LastPosition { get; set; }

    public static List<Evidence> TutorialDialogues { get; } = new List<Evidence>();
}
