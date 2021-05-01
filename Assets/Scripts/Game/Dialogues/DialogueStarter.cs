using System;
using UnityEngine;
using Game.Player;
using Game.UI.Panels.Dialogues;
using Game.Dialogues.Nodes;
using Game.Dialogues.Battles.Nodes;
using Game.Events;
using Game.Events.Instructions.Enums;
using Game.Interactions;
using Zenject;

namespace Game.Dialogues
{
    [AddComponentMenu("Game/Dialogues/DialogueStarter")]
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private Interactor interactor;

        [SerializeField] private KeyCode executeKeyCode;

        [SerializeField] private Dialogue dialogue;

        private Executor _executor;
        private DialogueUI _dialogueUI;
        private PlayerController _playerController;

        [Inject]
        private void Construct(Executor executor, DialogueUI dialogueUI, PlayerController playerController)
        {
            _executor = executor;
            _dialogueUI = dialogueUI;
            _playerController = playerController;
        }

        public void StartDialogue()
        {
            var tempHearts = _playerController.Stats.CurrentHearts;

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

                    if (replica.answerNodes != null && replica.answerNodes.Count > 0)
                    {
                        var answers = replica.GetAnswers(dialogue);

                        if (replica.IsAttackAnswers(dialogue))
                        {       
                            foreach (var answer in answers)
                            {
                                if (answer.GetType() == typeof(AttackAnswer))
                                {
                                    answer.onAnswerChoosen += Attack;
                                }

                                void Attack()
                                {
                                    var attackAnswer = (AttackAnswer) answer;

                                    if (!attackAnswer.correct)
                                    {
                                        _playerController.Stats.Damage(out bool lose);
                                        if (lose)
                                        {
                                            _dialogueUI.Clear();
                                            node = dialogue.StartReplica;                                                                                           

                                            _playerController.Stats.SetHearts(tempHearts);
                                        }
                                    }
                                }
                            }
                        }

                        _dialogueUI.Say(answers);
                        _dialogueUI.onAnswerChoosen += ExecuteAnswer;
                    }
                    else
                    {
                        Next(replica);
                    }

                    void ExecuteAnswer(Answer answer)
                    {
                        _dialogueUI.onAnswerChoosen -= ExecuteAnswer;
                        node = answer;

                        answer.onAnswerChoosen.Invoke();

                        Next(node);
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
                        Wait(End);
                    }
                    else
                    {
                        node = dialogue.GetNode(nextNode.toNode);
                        Wait(ExecuteNode);
                    }
                }

                void Wait(Action action)
                {
                    _executor.AddKeyInstruction(executeKeyCode, EKeyState.Pushed, StopWaiting, true);

                    _dialogueUI.SetWaiting(true);

                    void StopWaiting()
                    {
                        _dialogueUI.SetWaiting(false);
                        action.Invoke();
                    }
                }

                void End()
                {
                    _dialogueUI.Close();
                }
            }
        }

        private void OnEnable()
        {
            if (interactor != null)
            {
                interactor.Interaction += StartDialogue;
            }
        }

        private void OnDisable()
        {
            if (interactor != null)
            {
                interactor.Interaction -= StartDialogue;
            }
        }
    }
}
