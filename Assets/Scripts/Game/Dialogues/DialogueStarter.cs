using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Databases;
using Game.Interactions;

namespace Game.Dialogues
{
    [AddComponentMenu("Game/Dialogues/DialogueStarter")]
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private int dialogueId;
        [SerializeField] private Interactor interactor;

        [SerializeField] private DialoguesDatabase database;

        private void StartDialogue()
        {

        }

        private void OnEnable()
        {
            interactor.Interaction += StartDialogue;
        }

        private void OnDisable()
        {
            interactor.Interaction -= StartDialogue;
        }
    }
}
