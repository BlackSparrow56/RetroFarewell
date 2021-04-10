using System;
using UnityEngine;
using TMPro;

namespace Game.UI.Panels.Dialogue
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/AnswerUI")]
    public class AnswerUI : DialogueElement
    {
        [SerializeField] private TMP_Text numberText;

        public Action onAnswerChoose = () => { };

        public void Init(int number, string text)
        {
            numberText.text = $"{number}. -";
            contentText.text = text;
        }

        public void Choose()
        {
            onAnswerChoose.Invoke();
        }
    }
}
