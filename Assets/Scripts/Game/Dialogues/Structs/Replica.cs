using System;
using System.Collections.Generic;

namespace Game.Dialogues.Structs
{
    [Serializable]
    public struct Replica
    {
        public string text;

        public int node;
        public List<Answer> answers;
    }
}
