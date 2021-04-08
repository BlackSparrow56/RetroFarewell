using System.Collections.Generic;
using UnityEngine;
using Game.Dialogues.Structs;

namespace Game.Databases
{
    [CreateAssetMenu(menuName = "Databases/AttackAnswersDatabase", fileName = "AttackAnswersDatabase")]
    public class AttackAnswersDatabase : ScriptableObject
    {
        [SerializeField] private List<Replica> attackReplicas;
    }
}
