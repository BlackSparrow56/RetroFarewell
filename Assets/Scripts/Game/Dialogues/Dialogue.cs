using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Dialogues.Structs;

namespace Game.Dialogues
{
    [Serializable]
    public class Dialogue
    {
        [SerializeField] private int id;
        [SerializeField] private string name;

        [SerializeField] private Replica startReplica;
        [SerializeField] private List<Replica> replicas;

        public int Id => id;
        public string Name => name;

        public Replica StartReplica => startReplica;
        public List<Replica> Replicas => replicas;
    }
}
