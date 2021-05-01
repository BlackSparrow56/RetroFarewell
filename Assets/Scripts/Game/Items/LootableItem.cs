using UnityEngine;
using Game.Player;
using Zenject;

namespace Game.Items
{
    [AddComponentMenu("Game/Items/LootableItem")]
    public class LootableItem : MonoBehaviour
    {
        [SerializeField] private ItemVo vo;
        [SerializeField] private int count;

        private Inventory _inventory;

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _inventory = playerController.Inventory;
        }

        public void Take()
        {
            _inventory.Add(vo, count);
        }
    }
}
