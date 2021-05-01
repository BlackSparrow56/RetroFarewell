using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Lore.Notes;
using Utils.Extensions;
using TMPro;

namespace Game.UI.Panels.Glossary
{
    [AddComponentMenu("Game/UI/Panels/Glossary/GlossaryUI")]
    public class GlossaryUI : Panel
    {
        [SerializeField] private GameObject sectionButtonPrefab;
        [SerializeField] private GameObject notePrefab;

        [SerializeField] private Transform sectionButtonsContent;
        [SerializeField] private Transform notesContent;

        private List<GameObject> _sections = new List<GameObject>();
        private List<GameObject> _notes = new List<GameObject>();

        private Lore.Notes.Glossary _glossary;

        public override void Open()
        {
            base.Open();
            ClearSections();
            CreateSections();
        }

        public override void Close()
        {
            base.Close();
        }

        public void Set(Lore.Notes.Glossary glossary)
        {
            _glossary = glossary;
        }

        private void CreateSections()
        {
            foreach (var section in _glossary.Sections)
            {
                var sectionButton = Instantiate(sectionButtonPrefab, sectionButtonsContent);
                var component = sectionButton.GetComponent<SectionUI>();

                component.Set(section.name, CreateNotes);

                _sections.Add(sectionButton);

                void CreateNotes()
                {
                    ClearNotes();

                    foreach (var note in section.notes.Where(value => !value.hidden))
                    {
                        var noteObject = Instantiate(notePrefab, notesContent);
                        var component = noteObject.GetComponent<NoteUI>();

                        string text = $"<b>{note.name}</b>\n\n";
                        foreach (var paragraph in note.paragraphs)
                        {
                            text += paragraph.ToString() + "\n\n";
                        }

                        component.Set(text);

                        _notes.Add(noteObject);
                    }
                }
            }
        }

        private void ClearSections()
        {
            _sections.ForEach(value => Destroy(value));
            _sections.Clear();
        }

        private void ClearNotes()
        {
            _notes.ForEach(value => Destroy(value));
            _notes.Clear();
        }
    }
}
