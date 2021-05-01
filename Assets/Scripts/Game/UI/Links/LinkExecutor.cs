using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game.Databases;
using TMPro;
using Zenject;

namespace Game.UI.Links
{
    [AddComponentMenu("Game/UI/LinkExecutor")]
    public class LinkExecutor : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text text;

        [SerializeField] private LinkEventsContainer container;

        public LinkEventsContainer LinksContainer
        {
            get;
            set;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (LinksContainer == null)
            {
                LinksContainer = container;
            }

            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];

                foreach (var action in LinksContainer.linkEvents)
                {
                    if (linkInfo.GetLinkID() == action.id)
                    {
                        action.unityEvent.Invoke();
                        return;
                    }
                }

                foreach (var action in LinksContainer.links)
                {
                    if (linkInfo.GetLinkID() == action.key)
                    {
                        Application.OpenURL(action.value);
                        return;
                    }
                }
            }
        }
    }
}
