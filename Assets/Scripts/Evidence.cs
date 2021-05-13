using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Evidence : ScriptableObject
    {
        public string description;
        [TextArea] public string dialogue;
    }
}