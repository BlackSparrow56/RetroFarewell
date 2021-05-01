using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils.Structs;

namespace Game.Events
{
    public class UnityEventsQueue : MonoBehaviour
    {
        [SerializeField] private List<Pair<UnityEvent, float>> events;

        public void Execute()
        {
            StartCoroutine(ExecuteCoroutine());
        }

        private IEnumerator ExecuteCoroutine()
        {
            foreach (var @event in events)
            {
                @event.key.Invoke();
                yield return new WaitForSeconds(@event.value);
            }
        }
    }
}
