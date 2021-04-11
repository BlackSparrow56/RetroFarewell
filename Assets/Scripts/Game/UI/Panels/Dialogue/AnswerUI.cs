using System;
using UnityEngine;
using Game.Dialogues.Nodes;
using Utils.Extensions;
using TMPro;

namespace Game.UI.Panels.Dialogues
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/AnswerUI")]
    public class AnswerUI : DialogueElement
    {
        [SerializeField] private TMP_Text numberText;

        private Color _color;
        private int _number;

        private bool _choosen = false;

        private Answer _answer;

        public int Number => _number;
        public Answer Answer => _answer;

        public void SetColor(Color color)
        {
            _color = color;
        }

        public void SetNumber(int number)
        {
            _number = number;
        }

        public void SetAnswer(Answer answer)
        {
            _answer = answer;
        }

        public void Select(Color highlightColor, bool underline, out bool twice)
        {
            if (_choosen)
            {
                twice = true;
            }
            else
            {
                Highlight();
                twice = false;
            }

            _choosen = true;

            void Highlight()
            {
                contentText.text = $"- {_text.Colored(highlightColor)}";
                contentText.fontStyle = underline ? FontStyles.Underline : FontStyles.Normal;
            }
        }

        public void Deselect()
        {
            _choosen = false;

            contentText.text = $"- {_text.Colored(_color)}";
            contentText.fontStyle = FontStyles.Normal;
        }

        public override void Set()
        {
            numberText.text = $"{_number}. ";
            contentText.text = $"- {_text.Colored(_color)}";
        }
    }
}
