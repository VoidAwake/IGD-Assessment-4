using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class Evidence : ScriptableObject
    {
        public List<string> descriptions;
        public List<EvidencePiece> evidencePieces;
        [TextArea] public string dialogue;
        public Sprite speakerSprite;
    }
}