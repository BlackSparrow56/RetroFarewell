using System;
using UnityEngine;

namespace Game.Interactions
{
    public abstract class Interactor : MonoBehaviour
    {
        public abstract Action Interaction 
        {
            get; 
            set; 
        }
    }
}
