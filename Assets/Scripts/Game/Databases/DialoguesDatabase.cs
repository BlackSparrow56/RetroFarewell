using System.Linq;
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

        public Dialogue GetDialogueByNameAndId(string name, int id)
        {
            return dialogues.FirstOrDefault(value => value.Id == id && value.Name == name);
        }

        public Dialogue GetDialogueById(int id)
        {
            return dialogues.FirstOrDefault(value => value.Id == id);
        }

        public Dialogue GetDialogueByName(string name)
        {
            return dialogues.FirstOrDefault(value => value.Name == name);
        }
    }
}
