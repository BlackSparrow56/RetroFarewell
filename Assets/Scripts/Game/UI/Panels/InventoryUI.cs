using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Items;
using Game.Items.Enums;
using Game.Items.Structs;
using Utils.Extensions;
using TMPro;

namespace Game.UI.Panels
{
    [AddComponentMenu("Game/UI/Panels/InventoryUI")]
    public class InventoryUI : Panel
    {
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private Transform content;

        [SerializeField] private Image bigIcon;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;

        [SerializeField] private Inventory inventory;

        [SerializeField] private List<RarityColor> rarityColors;

        private readonly List<Slot> _slots = new List<Slot>();


        [ContextMenu("Show")]
        public void Show()
        {
            if (inventory.Items == null || inventory.Items.Count == 0)
            {
                return;
            }
            else
            {
                for (int i = 0; i < inventory.Items.Count; i++)
                {
                    var item = inventory.Items[i];

                    var slot = Instantiate(slotPrefab, content);
                    var component = slot.GetComponent<Slot>();

                    component.Set(item, GetColorByRarity(item.type.Rarity));

                    component.Button.onClick.RemoveAllListeners();
                    component.Button.onClick.AddListener(() => Choose(item));

                    _slots.Add(component);
                }
            }
        }

        [ContextMenu("Hide")]
        public void Hide()
        {
            var items = inventory.Items.Where(value => value.newItem).ToList();
            items.ForEach(value => value.newItem = false);

            _slots.ForEach(value => Destroy(value.gameObject));
            _slots.Clear();
        }

        private Color GetColorByRarity(EItemRarity rarity)
        {
            return rarityColors.FirstOrDefault(value => value.rarity == rarity).color;
        }

        private void Choose(Item item)
        {
            bigIcon.sprite = item.type.Icon;
            nameText.text = $"<b><color={GetColorByRarity(item.type.Rarity).ToHexadecimal()}>{item.type.Name}</color></b> {(item.count != 1 ? $"- {item.count}" : "")}";
            descriptionText.text = item.type.Description;
        }
    }
}
