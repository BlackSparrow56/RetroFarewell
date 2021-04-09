using System;
using Game.Interactions.Enums;

namespace Game.Interactions
{
    [Serializable]
    public class TriggerAction
    {
        public Action action = () => { };
        public ETriggerInteraction type;
    }
}