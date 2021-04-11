using System;
using System.Linq;
using System.Collections.Generic;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class Replica : Node
    {
        public string name;
        public List<int> answerNodes;

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
                else
                {
                    throw new Exception("Wrong node!");
                }
            }

            return list.AsEnumerable();
        }
    }
}
