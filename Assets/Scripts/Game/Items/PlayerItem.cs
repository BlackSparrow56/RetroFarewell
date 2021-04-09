using System;

namespace Game.Items
{
    [Serializable]
    public class PlayerItem : Item
    {
        public bool newItem;

        public PlayerItem(ItemVo type, int count) : base(type, count)
        {
            newItem = true;
        }
    }
}
