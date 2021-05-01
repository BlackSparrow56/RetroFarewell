using System;
using System.Linq;
using System.Collections.Generic;
using Game.Dialogues.Battles.Nodes;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class Replica : Node
    {
        public string name;
        public List<int> answerNodes;

        public bool IsAttackAnswers(Dialogue dialogue)
        {
            return dialogue.GetNode(answerNodes[0]).GetType() == typeof(AttackAnswer);
        }

        public IEnumerable<Answer> GetAnswers(Dialogue dialogue)
        {
            var list = new List<Answer>();

            foreach (var answerNode in answerNodes)
            {
                var node = dialogue.GetNode(answerNode);
                if (node.GetType() == typeof(Answer))
                {
                    list.Add((Answer) node);
                }
                else if (node.GetType() == typeof(AttackAnswer))
                {
                    list.Add((AttackAnswer) node);
                }
                else
                {
                    throw new Exception("Wrong node!");
                }
            }

            return list.AsEnumerable();
        }

        public IEnumerable<AttackAnswer> GetAttackAnswers(Dialogue dialogue)
        {
            var list = new List<AttackAnswer>();

            foreach (var answerNode in answerNodes)
            {
                var node = dialogue.GetNode(answerNode);
                if (node.GetType() == typeof(AttackAnswer))
                {
                    list.Add((AttackAnswer)node);
                }
                else
                {
                    throw new Exception("Wrong node!");
                }
            }

            return list.AsEnumerable();
        }
    }
}
