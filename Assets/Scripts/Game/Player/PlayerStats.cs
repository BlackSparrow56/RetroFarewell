using UnityEngine;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerStats")]
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int defaultHearts;

        private int _currentHearts;

        public int CurrentHearts => _currentHearts;

        private void Start()
        {
            _currentHearts = defaultHearts;
        }

        public void Damage(out bool lose)
        {
            _currentHearts -= 1;
            lose = _currentHearts <= 0;
        }

        public void Heal()
        {
            _currentHearts += 1;
        }

        public void FullHeal()
        {
            _currentHearts = defaultHearts;
        }

        public void SetHearts(int hearts)
        {
            _currentHearts = hearts;
        }
    }
}
