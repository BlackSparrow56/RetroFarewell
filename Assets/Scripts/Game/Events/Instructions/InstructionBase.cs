using System;

namespace Game.Events.Instructions
{
    public abstract class InstructionBase
    {
        protected Action _action = () => { };
        public Action Action => _action;

        protected abstract Func<bool> Condition
        {
            get;
        }

        public bool SelfDestroy
        {
            get;
        } = false;

        public InstructionBase(Action action)
        {
            _action = action;
        }

        public InstructionBase(Action action, bool selfDestroy) : this(action)
        {
            SelfDestroy = selfDestroy;
        }

        public virtual bool TryExecute()
        {
            if (Condition.Invoke())
            {
                _action.Invoke();
                return true;
            }

            return false;
        }
    }
}
