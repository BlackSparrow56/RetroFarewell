using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Interactions.Enums;

namespace Game.Interactions
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("Game/Interactions/Trigger")]
    public class Trigger : Interactor
    {
        [SerializeField] private List<TriggerAction> triggerActions;
        [SerializeField] private ETriggerInteraction interactionType;

        public override Action Interaction
        {
            get
            {
                var action = GetActionByType(interactionType);
                return action.action;
            }

            set
            {
                int index = triggerActions.IndexOf(GetActionByType(interactionType));
                triggerActions[index].action = value;
            }
        }

        private TriggerAction GetActionByType(ETriggerInteraction type)
        {
            return triggerActions.FirstOrDefault(value => value.type == type);
        }

        private bool Condition(Collider2D other)
        {
            var controller = other.GetComponent<InteractController>();
            if (controller != null)
            {
                return controller.Name == "Player";
            }

            return false;
        } 

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Condition(other))
            {
                GetActionByType(ETriggerInteraction.OnTriggerEnter).action.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Condition(other))
            {
                GetActionByType(ETriggerInteraction.OnTriggerExit).action.Invoke();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (Condition(other))
            {
                GetActionByType(ETriggerInteraction.OnTriggerStay).action.Invoke();
            }
        }
    }
}
