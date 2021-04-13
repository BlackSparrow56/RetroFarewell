using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Events.Instructions;
using Game.Events.Instructions.Enums;

namespace Game.Events
{
    [AddComponentMenu("Game/Events/Executor")]
    public class Executor : MonoBehaviour
    {
        // ѕоследн€€ инструкци€ каждой очереди провер€ютс€ каждый кадр.  огда она выполн€етс€, переходит к следующей.
        private readonly List<InstructionsQueue> _instructionsQueues = new List<InstructionsQueue>();
        // Ёти инструкции провер€ютс€ каждый кадр.
        private readonly List<InstructionBase> _everyFrameInstructions = new List<InstructionBase>();

        public void Execute(string text)
        {
            Debug.Log($"Execute: {text}");
        }

        public void AddQueue(InstructionsQueue queue)
        { 
            _instructionsQueues.Add(queue);
        }

        public void RemoveQueue(InstructionsQueue queue)
        {
            _instructionsQueues.Remove(queue);
        }

        public bool TryExecuteInstruction(InstructionBase instruction)
        {
            return instruction.TryExecute();
        }

        public void ExecuteInstruction(InstructionBase instruction)
        {
            instruction.TryExecute();
        }

        public ConditionInstruction AddConditionInstruction(Func<bool> condition, Action action, bool selfDestroy = false)
        {
            var instruction = new ConditionInstruction(condition, action, selfDestroy);
            _everyFrameInstructions.Add(instruction);

            return instruction;
        }

        public void RemoveConditionInstruction(ConditionInstruction instruction)
        {
            _everyFrameInstructions.Remove(instruction);
        }

        public KeyInstruction AddKeyInstruction(KeyCode keyCode, EKeyState state, Action action, bool selfDestroy = false)
        {
            var instruction = new KeyInstruction(keyCode, state, action, selfDestroy);
            _everyFrameInstructions.Add(instruction);

            return instruction;
        }

        public void RemoveKeyInstruction(KeyCode keyCode, EKeyState state, Action action)
        {
            _everyFrameInstructions.Remove(_everyFrameInstructions.FirstOrDefault(Condition));

            bool Condition(InstructionBase instruction)
            {
                if (instruction.GetType() == typeof(KeyInstruction))
                {
                    var target = (KeyInstruction) instruction;
                    return target.KeyCode == keyCode && target.TargetState == state && target.Action == action;
                }

                return false;
            }
        }

        public void RemoveKeyInstruction(KeyCode keyCode, EKeyState state)
        {
            _everyFrameInstructions.Remove(_everyFrameInstructions.FirstOrDefault(Condition));

            bool Condition(InstructionBase instruction)
            {
                if (instruction.GetType() == typeof(KeyInstruction))
                {
                    var target = (KeyInstruction) instruction;
                    return target.KeyCode == keyCode && target.TargetState == state;
                }

                return false;
            }
        }

        public void RemoveKeyInstruction(KeyInstruction instruction)
        {
            _everyFrameInstructions.Remove(instruction);
        }

        public void RemoveAllKeyInstructions(KeyCode keyCode)
        {
            _everyFrameInstructions.RemoveAll(Condition);

            bool Condition(InstructionBase instruction)
            {
                return instruction.GetType() == typeof(KeyInstruction) && ((KeyInstruction) instruction).KeyCode == keyCode;
            }
        }

        private void Update()
        {
            var incomingEveryFrame = new List<InstructionBase>(_everyFrameInstructions);
            foreach (var instruction in incomingEveryFrame)
            {
                bool executed = instruction.TryExecute();

                if (executed && instruction.SelfDestroy)
                {
                    _everyFrameInstructions.Remove(instruction);
                }
            }

            var incomingQueues = new List<InstructionsQueue>(_instructionsQueues);
            foreach (var queue in incomingQueues)
            {
                queue.TryExecuteLast(out bool last);
                if (last)
                {
                    _instructionsQueues.Remove(queue);
                }
            }
        }
    }
}
