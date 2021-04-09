using UnityEngine;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/UIController")]
    public class UIController : MonoBehaviour
    {
        [SerializeField] private KeyCode inventoryKeyCode;

        [SerializeField] private InventoryUI inventoryUI;

        private void Update()
        {
            if (Input.GetKeyDown(inventoryKeyCode))
            {
                inventoryUI.Toggle();
            }
        }
    }
}
