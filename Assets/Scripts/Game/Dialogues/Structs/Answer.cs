using System;

namespace Game.Dialogues.Structs
{
    [Serializable]
    public struct Answer
    {
        public string text;

        public int toNode; 
        public bool exit;
    }
}
