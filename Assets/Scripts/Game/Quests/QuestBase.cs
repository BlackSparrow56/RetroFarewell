using System;
using UnityEngine;

namespace Game.Quests
{
    [CreateAssetMenu(fileName = "QuestBase", menuName = "Quests/QuestBase")]
    public class QuestBase : ScriptableObject
    {
        [SerializeField] private int id;
 
        [SerializeField] new private string name;
        [SerializeField] [Multiline] private string description;

        [SerializeField] private EQuestType type;
        [SerializeField] private QuestBase nextQuest;

        public Action onQuestGetted = () => { };
        public Action onQuestPassed = () => { };

        public int Id => id;
        public string Name => name;
        public string Description => description;
        public EQuestType Type => type;
        public QuestBase NextQuest => nextQuest;

        public virtual void Get()
        {
            onQuestGetted.Invoke();
        }

        public virtual void Pass()
        {
            nextQuest?.Get();
            onQuestPassed.Invoke();
        }
    }
}
