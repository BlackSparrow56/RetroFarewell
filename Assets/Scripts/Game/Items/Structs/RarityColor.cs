using System;
using UnityEngine;
using Game.Items.Enums;

namespace Game.Items.Structs
{
    [Serializable]
    public struct RarityColor
    {
        public Color color;
        public EItemRarity rarity;
    }
}
