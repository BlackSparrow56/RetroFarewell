using System;
using UnityEngine;
using UnityEngine.Events;
using Game.Events;
using Game.Events.Instructions.Enums;
using Zenject;

namespace Game.Interactions
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("Game/Interactions/Trigger")]
    public class Trigger : Interactor
    {
        [SerializeField] private string targetName;

        [SerializeField] private bool buttonPerform;
        [SerializeField] private KeyCode keyCode;

        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] private UnityEvent onTriggerExit;

        private Action _interaction = () => { };
        public override Action Interaction
        {
            get => _interaction;
            set => _interaction = value;
        }

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
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
                    _executor.AddKeyInstruction(keyCode, EKeyState.Pushed, _interaction.Invoke, true);
                }
                else
                {
                    _interaction.Invoke();
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
                    _executor.RemoveKeyInstruction(keyCode, EKeyState.Pushed);
                }

                onTriggerExit.Invoke();
            }
        }
    }
}
