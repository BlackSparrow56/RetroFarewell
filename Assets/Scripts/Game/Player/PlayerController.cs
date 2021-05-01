using UnityEngine;
using Game.Items;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerController")]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private PlayerMovement movement;
        [SerializeField] new private PlayerCamera camera;

        [SerializeField] private Inventory inventory;

        [SerializeField] private SpriteRenderer spriteRenderer;

        public PlayerStats Stats => stats;
        public PlayerMovement Movement => movement;
        public PlayerCamera Camera => camera;

        public Inventory Inventory => inventory;

        public SpriteRenderer SpriteRenderer => spriteRenderer;

        public void MoveTo(Transform to)
        {
            transform.position = to.position;
        }
    }
}
