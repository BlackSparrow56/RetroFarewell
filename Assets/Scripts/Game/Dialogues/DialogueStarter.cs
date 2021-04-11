using System;
using UnityEngine;
using Game.UI.Panels.Dialogues;
using Game.Dialogues.Nodes;
using Game.Databases;
using Game.Interactions;
using Zenject;

namespace Game.Dialogues
{
    [AddComponentMenu("Game/Dialogues/DialogueStarter")]
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private int dialogueId;
        [SerializeField] private Interactor interactor;

        [SerializeField] private KeyCode executeKeyCode;

        [SerializeField] private DialoguesDatabase database;

        private Action execute = () => { };
        private bool _waiting;

        private DialogueUI _dialogueUI;

        [Inject]
        private void Construct(DialogueUI dialogueUI)
        {
            _dialogueUI = dialogueUI;
        }

        private void StartDialogue()
        {
            var dialogue = database.GetDialogueById(dialogueId);

            _dialogueUI.Clear();
            _dialogueUI.Set(dialogue);
            _dialogueUI.Open();

            Node node = dialogue.StartReplica;
            ExecuteNode();

            void ExecuteNode()
            {
                _dialogueUI.SetWaiting(false);

                if (node.GetType() == typeof(Replica))
                {
                    var replica = (Replica) node;

                    _dialogueUI.Say(replica);
                    _dialogueUI.Say(replica.GetAnswers(dialogue));
                    _dialogueUI.onAnswerChoosen += ExecuteAnswer;

                    void ExecuteAnswer(Answer answer)
                    {
                        _dialogueUI.onAnswerChoosen -= ExecuteAnswer;

                        Next(answer);
                    }   
                }
                else
                {
                    if (node.GetType() == typeof(DialogueEvent))
                    {
                        var dialogueEvent = (DialogueEvent) node;

                        _dialogueUI.Say(dialogueEvent);
                        dialogueEvent.unityEvent.Invoke();

                        Next(dialogueEvent);
                    }
                }

                void Next(Node nextNode)
                {
                    if (nextNode.exit)  
                    {
                        Wait(_dialogueUI.Close);
                    }
                    else
                    {
                        node = dialogue.GetNode(nextNode.toNode);
                        Wait(ExecuteNode);
                    }
                }

                void Wait(Action action)
                {
                    execute += StopWaiting;

                    _dialogueUI.SetWaiting(true);

                    void StopWaiting()
                    {
                        execute -= StopWaiting;
                        action.Invoke();
                    }
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(executeKeyCode))
            {
                execute.Invoke();
            }
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
