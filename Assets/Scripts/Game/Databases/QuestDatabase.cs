using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Quests;

namespace Game.Databases
{
    [CreateAssetMenu(fileName = "QuestDatabase", menuName = "Databases/QuestDatabase")]
    public class QuestDatabase : ScriptableObject
    {
        [SerializeField] private List<QuestBase> quests = new List<QuestBase>();

        public QuestBase GetQuestById(int id)
        {
            return quests.FirstOrDefault(value => value.Id == id);
        }

        public QuestBase GetQuestByName(string name)
        {
            return quests.FirstOrDefault(value => value.Name == name);
        }
    }
}
