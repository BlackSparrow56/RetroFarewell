using System;
using UnityEngine;

namespace Game.UI.Panels
{
    [Serializable]
    public class BindPanel
    {
        public string name;
        public KeyCode keyCode;
        public Panel panel;
    }
}
