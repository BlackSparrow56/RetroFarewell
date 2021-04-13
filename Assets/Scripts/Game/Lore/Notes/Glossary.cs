using System.Collections.Generic;
using UnityEngine;

namespace Game.Lore.Notes
{
    public class Glossary : MonoBehaviour
    {
        [SerializeField] private List<Section> sections;

        public List<Section> Sections => sections;
    }
}
