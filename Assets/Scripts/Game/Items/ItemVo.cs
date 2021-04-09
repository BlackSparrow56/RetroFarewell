using UnityEngine;
using Game.Items.Enums;

namespace Game.Items
{
    [CreateAssetMenu(fileName = "ItemVo", menuName = "Items/ItemVo")]
    public class ItemVo : ScriptableObject
    {
        [SerializeField] new private string name;
        [SerializeField] private string description;

        [SerializeField] private Sprite icon;

        [SerializeField] private EItemRarity rarity;
        [SerializeField] private EItemType type;

        public string Name => name;
        public string Description => description;

        public Sprite Icon => icon;

        public EItemRarity Rarity => rarity;
        public EItemType Type => type;
    }
}
