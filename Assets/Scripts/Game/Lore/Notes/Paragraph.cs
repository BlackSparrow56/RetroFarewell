using System;
using System.Collections.Generic;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Paragraph
    {
        public string content;
        public string description;
        public List<Note> notes;
    }
}
