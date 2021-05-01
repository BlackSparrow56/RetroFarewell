using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Game.Player;
using Game.Dialogues;
using Zenject;

namespace Game.Events
{
    [AddComponentMenu("Game/Events/LoreEvents")]
    public class LoreEvents : MonoBehaviour
    {
        [SerializeField] private float punkMagnitude;
        [SerializeField] private Transform yardSpawnPoint;
        [SerializeField] private DialogueStarter punkDialogue;

        [SerializeField] private PlayerController player;

        [SerializeField] private UnityEvent start;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        public void SubscribePunk()
        {
            _executor.AddConditionInstruction(Condition, Action, true);

            bool Condition()
            {
                return (player.transform.position - yardSpawnPoint.position).magnitude > punkMagnitude;
            }

            void Action()
            {
                punkDialogue.StartDialogue();
            }
        }

        public void OpenMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        private void Start()
        {
            start.Invoke();
        }
    }
}
