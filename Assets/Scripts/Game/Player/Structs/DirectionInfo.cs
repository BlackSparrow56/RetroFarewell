using System;
using UnityEngine;

namespace Game.Player.Structs
{
    [Serializable]
    public struct DirectionInfo
    {
        public Vector2 direction;
        public KeyCode keyCode;
        public string name;
    }
}
