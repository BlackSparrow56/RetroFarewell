using System;
using UnityEngine;

namespace Game.Player.Structs
{
    [Serializable]
    public struct DirectionInfo
    {
        public string name;
        public Vector2 direction;

        public KeyCode keyCode;
    }
}
