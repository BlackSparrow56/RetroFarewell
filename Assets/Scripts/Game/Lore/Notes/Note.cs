using System;
using System.Linq;
using System.Collections.Generic;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Note
    {
        public string name;
        public List<Paragraph> paragraphs;

        public bool hidden;

        public Paragraph GetParagraphByName(string name)
        {
            var paragraph = paragraphs.FirstOrDefault(value => value.heading == name);
            return paragraph;
        }
    }
}