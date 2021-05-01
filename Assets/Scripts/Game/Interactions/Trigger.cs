using System;
using UnityEngine;
using UnityEngine.Events;
using Game.Events;
using Game.Events.Instructions;
using Game.Events.Instructions.Enums;
using Zenject;

namespace Game.Interactions
{
    [RequireComponent(typeof(Collider2D))]
    [AddComponentMenu("Game/Interactions/Trigger")]
    public class Trigger : Interactor
    {
        [SerializeField] private string targetName;

        [SerializeField] private bool buttonPerform;
        [SerializeField] private bool actionSelfDestroy;

        [SerializeField] private KeyCode keyCode;

        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] private UnityEvent onTriggerExit;
        [SerializeField] private UnityEvent onInteractionPerformed;

        private Action _interaction = () => { };
        public override Action Interaction
        {
            get => _interaction + onInteractionPerformed.Invoke;
            set => _interaction = value;
        }

        private KeyInstruction _keyInstruction;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        private void Action()
        {
            Interaction.Invoke();
            if (actionSelfDestroy)
            {
                onTriggerExit.Invoke();
            }
        }
        
        private bool Condition(Collider2D other)
        {
            var controller = other.GetComponent<InteractController>();
            if (controller != null)
            {
                return controller.Name == targetName;
            }

            return false;
        } 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Condition(other))
            {
                if (buttonPerform)
                {
                    _keyInstruction = _executor.AddKeyInstruction(keyCode, EKeyState.Pushed, Action, actionSelfDestroy);
                }
                else
                {
                    Action();
                }

                onTriggerEnter.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Condition(other))
            {
                if (buttonPerform)
                {
                    _executor.RemoveKeyInstruction(_keyInstruction);
                    _keyInstruction = null;
                }

                onTriggerExit.Invoke();
            }
        }
    }
}
