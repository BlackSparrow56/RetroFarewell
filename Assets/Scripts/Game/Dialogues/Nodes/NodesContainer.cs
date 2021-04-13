using System;
using System.Collections.Generic;
using Game.Dialogues.Battles.Nodes;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class NodesContainer
    {
        public List<Answer> answers;
        public List<DialogueEvent> actions;
        public List<Replica> replicas;

        public List<AttackReplica> attackReplicas;
        public List<AttackAnswer> attackAnswers;
    }
}
