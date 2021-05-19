using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Connection
    {
        public List<EvidencePiece> components = new List<EvidencePiece>();
        public EvidencePiece evidencePiece;
    }
}