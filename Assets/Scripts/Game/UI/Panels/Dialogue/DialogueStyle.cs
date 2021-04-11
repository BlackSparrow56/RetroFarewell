using System;
using UnityEngine;

namespace Game.UI.Panels.Dialogues
{
    [Serializable]
    public class DialogueStyle
    {
        public Color actionColor;
        public Color keyPhraseColor;

        public Color passiveAnswerVariantColor;
        public Color activeAnswerVariantColor;
        public bool underlineAnswerVariants;
    }
}
