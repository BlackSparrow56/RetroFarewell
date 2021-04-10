using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Items;

namespace Game.Databases
{
    [CreateAssetMenu(fileName = "ItemsDatabase", menuName = "Databases/ItemsDatabase")]
    public class ItemsDatabase : ScriptableObject
    {
        [SerializeField] private List<ItemVo> items;

        public ItemVo GetItemById(int id)
        {
            return items.FirstOrDefault(value => value.Id == id);
        }

        public ItemVo GetItemByName(string name)
        {
            return items.FirstOrDefault(value => value.Name == name);
        }
    }
}
