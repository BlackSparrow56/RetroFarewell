using System;
using UnityEngine;
using Game.Events.Instructions.Enums;

namespace Game.Events.Instructions
{
    public class KeyInstruction : InstructionBase
    {
        protected KeyCode _keyCode;
        protected EKeyState _targetState;

        protected override Func<bool> Condition => Predicate;

        public KeyCode KeyCode => _keyCode;
        public EKeyState TargetState => _targetState;

        public KeyInstruction(KeyCode keyCode, EKeyState targetState, Action action) : base(action)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }

        public KeyInstruction(KeyCode keyCode, EKeyState targetState, Action action, bool selfDestroy) : base(action, selfDestroy)
        {
            _keyCode = keyCode;
            _targetState = targetState;
        }

        private bool Predicate()
        {
            switch (_targetState)
            {
                case EKeyState.Untouched:
                    if (!Input.GetKey(_keyCode))
                    {
                        return true;
                    }
                    break;
                case EKeyState.Pushed:
                    if (Input.GetKeyDown(_keyCode))
                    {
                        return true;
                    }
                    break;
                case EKeyState.Holded:
                    if (Input.GetKey(_keyCode))
                    {
                        return true;
                    }
                    break;
                case EKeyState.Released:
                    if (Input.GetKeyUp(_keyCode))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
