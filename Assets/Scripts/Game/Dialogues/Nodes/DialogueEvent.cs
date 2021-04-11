using System;
using UnityEngine.Events;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class DialogueEvent : Node
    {
        public UnityEvent unityEvent;
    }
}