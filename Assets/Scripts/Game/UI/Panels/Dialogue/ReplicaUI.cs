using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Extensions;
using TMPro;

namespace Game.UI.Panels.Dialogues
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/ReplicaUI")]
    public class ReplicaUI : DialogueElement
    {
        private Color _nameColor = Color.white;
        private string _name = "Name";

        public bool LeftAlignment
        {
            get
            {
                return contentText.horizontalAlignment == HorizontalAlignmentOptions.Left;
            }

            set
            {
                if (value)
                {
                    contentText.horizontalAlignment = HorizontalAlignmentOptions.Left;
                }
                else
                {
                    contentText.horizontalAlignment = HorizontalAlignmentOptions.Right;
                }
            }
        }

        public void SetName(string name, Color color)
        {
            _name = name;
            _nameColor = color;
        }

        public override void Set()
        {
            contentText.text = $"<b>{_name.Colored(_nameColor)}</b>\n{_text}";
        }
    }
}
