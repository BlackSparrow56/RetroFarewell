using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.UI.Links;
using Game.UI.Panels.Dialogues.Structs;
using Game.Dialogues;
using Game.Dialogues.Nodes;
using Game.Databases;
using Utils.Extensions;
using TMPro;

namespace Game.UI.Panels.Dialogues
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/DialogueUI")]
    public class DialogueUI : Panel
    {
        [SerializeField] private GameObject answerPrefab;
        [SerializeField] private GameObject eventPrefab;
        [SerializeField] private GameObject replicaPrefab;

        [SerializeField] private Transform content;

        [SerializeField] private Image avatar;
        [SerializeField] private Sprite defaultAvatar;

        [SerializeField] private ShimmeryHint hint;

        [SerializeField] private DialogueStyle style;

        [SerializeField] private PersonsDatabase personsDatabase;

        [SerializeField] private List<NumberKeyCodePair> numberKeyCodePairs;

        public Action<Answer> onAnswerChoosen = _ => { };

        private List<GameObject> _dialogue = new List<GameObject>();
        private List<AnswerUI> _answers = new List<AnswerUI>();

        private AnswerUI _currentAnswer;

        private int _current = 0;
        private bool _choosing = false;

        private LinkEventsContainer _linksContainer;

        public override void Open()
        {
            base.Open();
            _UIController.CanOpenPanel = false;
        }

        public override void Close()
        {
            base.Close();
            _UIController.CanOpenPanel = true;
        }

        public void Set(Dialogue dialogue)
        {
            _linksContainer = dialogue.LinksContainer;
        }

        public void Clear()
        {
            _dialogue.ForEach(value => Destroy(value));
            _dialogue.Clear();

            _current = 0;
        }

        public void Say(Replica replica)
        {
            var replicaObject = Instantiate(replicaPrefab, content);
            var component = replicaObject.GetComponent<ReplicaUI>();

            var person = personsDatabase.GetPersonByName(replica.name); 
            var color = person != null ? person.nameColor : Color.white;

            avatar.sprite = person.avatar != null ? person.avatar : defaultAvatar;

            component.SetText(replica.text);
            component.SetName(replica.name, color);
            component.SetContainer(_linksContainer);

            component.LeftAlignment = _current % 2 == 0;

            component.Set();

            _dialogue.Add(replicaObject);

            _current++;
        }

        public void Say(DialogueEvent action)
        {
            var eventObject = Instantiate(eventPrefab, content);
            var component = eventObject.GetComponent<EventUI>();

            component.SetText($"{action.text.Colored(style.actionColor)}");
            component.SetContainer(_linksContainer);
            component.Set();

            _dialogue.Add(eventObject);
        }

        public void Say(IEnumerable<Answer> answers)
        {
            var list = answers.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var answer = list[i];

                var answerObject = Instantiate(answerPrefab, content);
                var component = answerObject.GetComponent<AnswerUI>();

                component.SetText(answer.text);
                component.SetNumber(i + 1);
                component.SetColor(style.passiveAnswerVariantColor);
                component.SetAnswer(answer);
                component.SetContainer(_linksContainer);

                component.Set();

                _dialogue.Add(answerObject);
                _answers.Add(component);
            }

            _choosing = true;
        }

        public void SetWaiting(bool waiting)
        {
            hint.SetActive(waiting);
        }

        private void Update()
        {
            if (_choosing)
            {
                var tapped = numberKeyCodePairs.FirstOrDefault(value => Input.GetKeyDown(value.keyCode));
                var answer = _answers.FirstOrDefault(value => value.Number == tapped.number);

                if (answer != null)
                {
                    if (answer != _currentAnswer)
                    {
                        _currentAnswer?.Deselect();
                    }

                    answer.Select(style.activeAnswerVariantColor, style.underlineAnswerVariants, out bool twice);
                    _currentAnswer = answer;

                    if (twice)
                    {
                        _answers.Clear();
                        _currentAnswer = null;
                        _choosing = false;

                        onAnswerChoosen.Invoke(answer.Answer);
                    }
                }

                /*
                for (int i = 0; i < _answers.Count; i++)
                {
                    if (Input.GetKeyDown(numberKeyCodePairs[i].keyCode))
                    {
                        _answers[i].Choose(style.activeAnswerVariantColor, style.underlineAnswerVariants, out bool twice);
                        if (twice)
                        {
                            _answers.Clear();
                            onAnswerChoosen.Invoke(_answers[i].Answer);
                        }
                    }
                }
                */
            }
        }
    }
}
