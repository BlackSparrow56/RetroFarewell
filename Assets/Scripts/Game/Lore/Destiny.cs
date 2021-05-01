using System;
using UnityEngine;

namespace Game.Lore
{
    [Serializable]
    public class Destiny
    {
        public string name;
        [Multiline] public string description;

        public Sprite sprite;
    }
}
