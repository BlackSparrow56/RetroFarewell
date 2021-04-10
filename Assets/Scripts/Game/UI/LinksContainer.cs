using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/LinksContainer")]
    public class LinksContainer : MonoBehaviour
    {
        [SerializeField] private List<LinkEvent> linkEvents;

        public List<LinkEvent> LinkEvents => linkEvents;

        public void Log()
        {
            Debug.Log($"LOG");
        }
    }
}
