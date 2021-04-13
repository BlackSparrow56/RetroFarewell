using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Lore.Notes;
using Game.Events.Instructions;
using Game.Events.Instructions.Enums;

namespace Game.Events
{
    [AddComponentMenu("Game/Events/Executor")]
    public class Executor : MonoBehaviour
    {
        [SerializeField] private Glossary glossary;

        private readonly List<InstructionBase> _everyFrameInstructions = new List<InstructionBase>();
        public List<InstructionBase> EveryFrameInstructions => _everyFrameInstructions;

        public void Execute(string text)
        {
            Debug.Log($"Execute: {text}");
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
            var incoming = new List<InstructionBase>(_everyFrameInstructions);

            foreach (var instruction in incoming)
            {
                bool executed = instruction.TryExecute();

                if (executed && instruction.SelfDestroy)
                {
                    _everyFrameInstructions.Remove(instruction);
                }
            }
        }
    }
}
