using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Lore
{
    [Serializable]
    public class Note : MonoBehaviour
    {
        public string content;
        public List<Note> nestedNotes;
    }
}