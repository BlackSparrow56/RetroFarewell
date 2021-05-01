using System;
using UnityEngine;

namespace Game.Lore
{
    [Serializable]
    public class Person
    {
        public string name;
        public Color nameColor; // Цвет имени в панели диалогов.
        public Sprite avatar;
    }
}
