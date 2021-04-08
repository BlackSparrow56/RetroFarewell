using System;

namespace Game.Items
{
    [Serializable]
    public class Item
    {
        public ItemVo type;
        public int count;

        public Item(ItemVo type, int count)
        {
            this.type = type;
            this.count = count;
        }
    }
}
