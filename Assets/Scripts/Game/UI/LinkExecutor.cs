using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Databases;
using TMPro;
using Zenject;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/LinkExecutor")]
    public class LinkExecutor : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text text;

        private LinksContainer _linksContainer;

        [Inject]
        private void Construct(LinksContainer linksContainer)
        {
            _linksContainer = linksContainer;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];

                foreach (var action in _linksContainer.LinkEvents)
                {
                    if (linkInfo.GetLinkID() == action.id)
                    {
                        action.unityEvent.Invoke();
                    }
                }
            }
        }
    }
}
