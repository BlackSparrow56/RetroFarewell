using UnityEngine;
using UnityEngine.UI;
using Game.Items;
using Utils.Extensions;
using TMPro;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/Slot")]
    public class Slot : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private Image iconImage;
        [SerializeField] private GameObject mark;

        [SerializeField] private Button button;
        public Button Button => button;

        public void Set(PlayerItem item, Color color)
        {
            nameText.text = $"<b><color={color.ToHexadecimal()}>{item.type.Name}</color></b> {(item.count != 1 ? $"- {item.count}" : "")}";
            iconImage.sprite = item.type.Icon;
            mark.SetActive(item.newItem);
        }
    }
}
