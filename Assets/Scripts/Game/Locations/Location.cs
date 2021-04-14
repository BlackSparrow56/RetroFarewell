using System;
using UnityEngine;

namespace Game.Locations
{
    [Serializable]
    public class Location
    {
        public string name;
        public GameObject location;
        public Rect rect;
    }
}
