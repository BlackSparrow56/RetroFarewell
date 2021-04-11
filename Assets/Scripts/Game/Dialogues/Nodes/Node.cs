using System;

namespace Game.Dialogues.Nodes
{
    [Serializable]
    public class Node
    {
        public string text;

        public int node;
        public int toNode;
        public bool exit;
    }
}
