using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public static class PersistentData
{
    public static List<Evidence> FoundEvidence { get; } = new List<Evidence>();
    
    public static List<Evidence> TutorialDialogues { get; } = new List<Evidence>();

    public static List<int> OpenedScenes { get; } = new List<int>();
    
    public static int PreviousScene { get; set; }

    public static bool FirstLoad { get; set; } = true;
}
