using System;
using UnityEngine;

namespace Game.Locations
{
    [Serializable]
    public class Location
    {
        public string name;
        public float cameraSize;
        public GameObject location;
        public Rect rect;

        public AudioClip ambience;
    }
}
