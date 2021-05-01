using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Lore.Notes;
using Game.Locations;

namespace Game.Saves
{
    [Serializable]
    public class Save
    {
        public string currentLocationName;
        public Vector2 playerPosition;
        public Glossary currentGlossary;
    }
}
