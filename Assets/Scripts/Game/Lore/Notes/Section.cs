using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Section
    {
        public string name;
        public List<Note> notes;
    }
}
