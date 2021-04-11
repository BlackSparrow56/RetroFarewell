using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Lore.Notes;

namespace Game.Events
{
    [AddComponentMenu("Game/Events/Executor")]
    public class Executor : MonoBehaviour
    {
        [SerializeField] private Glossary glossary;
        
        public void Execute(string text)
        {
            Debug.Log($"Execute: {text}");
        }
    }
}
