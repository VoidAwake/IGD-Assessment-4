using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public static class PersistentData
{
    private static List<Evidence> foundEvidence = new List<Evidence>();
    public static List<Evidence> FoundEvidence { get; } = new List<Evidence>();
}
