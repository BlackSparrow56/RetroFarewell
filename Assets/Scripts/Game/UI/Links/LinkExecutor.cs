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

        public LinkEventsContainer LinksContainer
        {
            get;
            set;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];

                foreach (var action in LinksContainer.linkEvents)
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
