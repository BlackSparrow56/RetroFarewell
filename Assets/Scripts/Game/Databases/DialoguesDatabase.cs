using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Dialogues;

namespace Game.Databases
{
    [CreateAssetMenu(menuName = "Databases/DialoguesDatabase", fileName = "DialoguesDatabase")]
    public class DialoguesDatabase : ScriptableObject
    {
        [SerializeField] private AttackAnswersDatabase attackAnswersDatabase;

        [SerializeField] private List<Dialogue> dialogues;
    }
}
