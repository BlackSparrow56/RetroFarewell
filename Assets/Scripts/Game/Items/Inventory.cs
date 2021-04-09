using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    [AddComponentMenu("Game/Items/Inventory")]
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<PlayerItem> items;

        public List<PlayerItem> Items => items;

        public void Add(ItemVo type, int count)
        {
            var first = items.FirstOrDefault(value => value.type == type);
            if (first != default)
            {
                first.count += count;
            }
            else
            {
                items.Add(new PlayerItem(type, count));
            }
        }

        public void Add(Item item)
        {
            Add(item.type, item.count);
        }

        public bool TryRemove(ItemVo type, int count)
        {
            var first = items.FirstOrDefault(value => value.type == type);
            if (first != default && first.count >= count)
            {
                Remove(type, count);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryRemove(Item item)
        {
            return TryRemove(item.type, item.count);
        }

        private void Remove(ItemVo type, int count)
        {
            var first = items.FirstOrDefault(value => value.type == type);
            if (first.count == count)
            {
                items.Remove(first);
            }
            else
            {
                first.count -= count;
            }
        }
    }
}
