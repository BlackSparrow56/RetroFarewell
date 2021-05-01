using UnityEngine;
using UnityEngine.Events;

namespace Game.Map
{
    [AddComponentMenu("Game/Map/Disappearing")]
    public class Disappearing : MonoBehaviour
    {
        [SerializeField] private UnityEvent onDisappear;

        private bool _disappearing = false;

        public void Disappear()
        {
            _disappearing = true;
        }

        private void OnBecameInvisible()
        {
            if (_disappearing)
            {
                onDisappear.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
