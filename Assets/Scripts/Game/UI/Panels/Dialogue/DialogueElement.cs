using UnityEngine;
using Game.UI.Links;
using TMPro;

namespace Game.UI.Panels.Dialogues
{
    [RequireComponent(typeof(LinkExecutor))]
    public abstract class DialogueElement : MonoBehaviour
    {
        [SerializeField] protected TMP_Text contentText;
        [SerializeField] protected LinkExecutor linkExecutor;

        protected string _text = "Text";

        public void SetText(string text)
        {
            _text = text;
        }

        public void SetContainer(LinkEventsContainer container)
        {
            linkExecutor.LinksContainer = container;
        }

        public abstract void Set();
    }
}
