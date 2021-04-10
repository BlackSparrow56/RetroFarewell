using System;
using UnityEngine.Events;

namespace Game.Dialogues.Structs
{
    [Serializable]
    public struct DialogueAction
    {
        public string description;
        public UnityAction action;
    }
}