using System;
using UnityEngine;

namespace Game.Interactions
{
    public class Trigger : MonoBehaviour
    {
        public Action<Collider> onTriggerEnter = _ => { };
        public Action<Collider> onTriggerExit = _ => { };
        public Action<Collider> onTriggerStay = _ => { };

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            onTriggerStay.Invoke(other);
        }
    }
}
