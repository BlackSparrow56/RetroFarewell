using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils.Structs
{
    [Serializable]
    public class Link : MonoBehaviour
    {
        public string id;
        public UnityAction action;
    }
}
