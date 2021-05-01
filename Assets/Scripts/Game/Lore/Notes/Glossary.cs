using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Lore.Notes
{
    public class Glossary : MonoBehaviour
    {
        [SerializeField] private List<Section> sections;

        public List<Section> Sections => sections;

        public void ShowNote(string noteName)
        {
            var note = GetNoteByName(noteName);

            note.hidden = false;
        }

        public void ShowParagraph(string noteName, string heading)
        {
            var note = GetNoteByName(noteName);
            var paragraph = note.GetParagraphByName(heading);

            paragraph.hidden = false;
        }

        private Note GetNoteByName(string name)
        {
            var notes = sections.SelectMany(section => section.notes);
            var note = notes.FirstOrDefault(note => note.name == name);

            return note;
        }

        public void ShowParagraph(string noteNameAndHeading)
        {
            string[] parsed = noteNameAndHeading.Split('/');
            ShowParagraph(parsed[0], parsed[1]);
        }
    }
}
