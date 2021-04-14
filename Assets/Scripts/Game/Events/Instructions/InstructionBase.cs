using System;

namespace Game.Events.Instructions
{
    public abstract class InstructionBase
    {
        protected virtual Action Action
        {
            get;
        }

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
            Action = action;
        }

        public InstructionBase(Action action, bool selfDestroy) : this(action)
        {
            SelfDestroy = selfDestroy;
        }

        public virtual bool TryExecute()
        {
            if (Condition.Invoke())
            {
                Action.Invoke();
                return true;
            }

            return false;
        }
    }
}
