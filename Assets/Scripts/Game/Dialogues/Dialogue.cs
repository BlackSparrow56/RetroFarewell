using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.UI.Links;
using Game.Dialogues.Nodes;

namespace Game.Dialogues
{
    [Serializable]
    public class Dialogue
    {
        [SerializeField] private int id;
        [SerializeField] private string name;

        [SerializeField] private Replica startReplica;

        [SerializeField] private NodesContainer nodesContainer;
        [SerializeField] private LinkEventsContainer linksContainer;

        public int Id => id;
        public string Name => name;

        public Replica StartReplica => startReplica;
        public NodesContainer NodesContainer => nodesContainer;

        public LinkEventsContainer LinksContainer => linksContainer;

        public Node GetNode(int node)
        {
            Node target = null;

            if (node == startReplica.node)
            {
                target = startReplica;
            }
            if (target == null)
            {
                target = Find(nodesContainer.actions);
            }
            if (target == null)
            {
                target = Find(nodesContainer.answers);
            }
            if (target == null)
            {
                target = Find(nodesContainer.replicas);
            }

            return target;

            Node Find(IEnumerable<Node> nodes)
            {
                return nodes.FirstOrDefault(value => value.node == node);
            }
        }
    }
}
