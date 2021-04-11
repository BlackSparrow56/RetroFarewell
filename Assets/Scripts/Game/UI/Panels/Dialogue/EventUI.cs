using UnityEngine;
using Utils.Extensions;

namespace Game.UI.Panels.Dialogues
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/EventUI")]
    public class EventUI : DialogueElement
    {
        private Color _color;

        public void SetColor(Color color)
        {
            _color = color;
        }

        public override void Set()
        {
            contentText.text = $"{_text.Colored(_color)}";
        }
    }
}
