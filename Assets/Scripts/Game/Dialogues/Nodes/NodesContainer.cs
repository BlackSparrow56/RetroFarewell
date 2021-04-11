using System;
using System.Collections.Generic;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class NodesContainer
    {
        public List<Answer> answers;
        public List<DialogueEvent> actions;
        public List<Replica> replicas;
    }
}
