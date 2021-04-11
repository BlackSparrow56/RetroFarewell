using System;
using UnityEngine.Events;

namespace Game.UI.Links
{
    [Serializable]
    public class LinkEvent
    {
        public string id;
        public UnityEvent unityEvent;

        public LinkEvent(string id)
        {
            this.id = id;
        }
    }
}
