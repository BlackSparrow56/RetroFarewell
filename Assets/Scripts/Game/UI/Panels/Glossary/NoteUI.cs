using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI.Panels.Glossary
{
    [AddComponentMenu("Game/UI/Panels/Glossary/NoteUI")]
    public class NoteUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Set(string text)
        {
            this.text.text = text;
        }
    }
}
