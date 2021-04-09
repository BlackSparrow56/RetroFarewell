using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactions
{
    [Serializable]
    public class Interaction
    {
        public string name;
        public Action action;
    }
}