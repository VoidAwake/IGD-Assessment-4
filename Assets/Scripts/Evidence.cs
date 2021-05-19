using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Evidence : ScriptableObject
    {
        public List<string> descriptions;
        [TextArea] public string dialogue;
        public Sprite speakerSprite;
    }
}