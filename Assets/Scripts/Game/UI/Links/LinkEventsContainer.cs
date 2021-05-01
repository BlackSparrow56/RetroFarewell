using System;
using System.Collections.Generic;
using Utils.Structs;

namespace Game.UI.Links
{
    [Serializable]
    public class LinkEventsContainer
    {
        public List<LinkEvent> linkEvents;
        public List<Pair<string, string>> links;
    }
}
