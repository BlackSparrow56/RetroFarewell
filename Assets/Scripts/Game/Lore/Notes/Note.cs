using System;
using System.Collections.Generic;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Note
    {
        public string name;
        public string content;

        public List<Note> nestedNotes;

        public bool hidden;
    }
}