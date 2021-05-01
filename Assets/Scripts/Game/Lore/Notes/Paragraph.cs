using System;
using UnityEngine;
using Utils.Extensions;

namespace Game.Lore.Notes
{
    [Serializable]
    public class Paragraph
    {
        public string heading;
        public Color headingColor;

        [TextArea] public string content;

        public bool hidden;

        public override string ToString()
        {
            return $"{heading.Bold()}\n{content}";
        }
    }
}
