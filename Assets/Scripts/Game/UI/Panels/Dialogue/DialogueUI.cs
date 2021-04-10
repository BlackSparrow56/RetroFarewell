using System.Collections.Generic;
using UnityEngine;
using Game.Dialogues.Structs;
using TMPro;

namespace Game.UI.Panels.Dialogue
{
    [AddComponentMenu("Game/UI/Panels/Dialogue/DialogueUI")]
    public class DialogueUI : Panel
    {
        [SerializeField] private GameObject replicaPrefab;
        [SerializeField] private GameObject actionPrefab;
        [SerializeField] private GameObject answerPrefab;

        [SerializeField] private Transform content;

        private List<GameObject> _dialogue = new List<GameObject>();
        private List<Answer> _answers = new List<Answer>();

        public override void Toggle()
        {
            base.Toggle();
            _UIController.CanOpenPanel = !_UIController.CanOpenPanel;
        }

        public void Clear()
        {
            _dialogue.ForEach(value => Destroy(value));
            _dialogue.Clear();
        }

        public void Say(Replica replica)
        {
            var replicaObject = Instantiate(replicaPrefab, content);
            var component = replicaObject.GetComponent<ReplicaUI>();

            component.Set(replica.text);
        }

        public void Say(DialogueAction action)
        {

        }

        public void Say(IEnumerable<Answer> answers)
        {

        }
    }
}
