using System;

namespace Game.Events.Instructions
{
    public class ConditionInstruction : InstructionBase
    {
        private Func<bool> _condition = () => false;
        protected override Func<bool> Condition
        {
            get => _condition;
        }

        public ConditionInstruction(Func<bool> condition, Action action) : base(action)
        {
            _condition = condition;
        }

        public ConditionInstruction(Func<bool> condition, Action action, bool selfDestroy) : base(action, selfDestroy)
        {
            _condition = condition;
        }
    }
}
