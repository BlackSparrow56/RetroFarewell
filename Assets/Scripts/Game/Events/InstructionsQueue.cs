using System.Linq;
using System.Collections.Generic;
using Game.Events.Instructions;
using UnityEngine;

namespace Game.Events
{
    public class InstructionsQueue
    {
        private readonly List<InstructionBase> _instructions = new List<InstructionBase>();

        public InstructionsQueue(params InstructionBase[] instructions) : this(instructions.AsEnumerable()) 
        { 
           
        }

        public InstructionsQueue(IEnumerable<InstructionBase> instructions)
        {
            Add(instructions);
        }

        public bool TryExecuteLast(out bool last)
        {
            last = false;

            if (_instructions.Count != 0)
            {
                bool executed = _instructions.Last().TryExecute();
                if (executed)
                {
                    Skip();
                    last = _instructions.Count == 0;
                }
            }

            return false;
        }

        public void Add(params InstructionBase[] instructions)
        {
            Add(instructions.AsEnumerable());
        }

        public void Add(IEnumerable<InstructionBase> instructions)
        {
            _instructions.AddRange(instructions);
        }

        public void Reverse()
        {
            _instructions.Reverse();
        }

        public void Skip()
        {
            _instructions.Remove(_instructions.Last());
        }
    }
}
