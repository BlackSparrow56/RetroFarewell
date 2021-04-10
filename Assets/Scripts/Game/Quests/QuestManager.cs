using UnityEngine;
using Game.Databases;

namespace Game.Quests
{
    [AddComponentMenu("Quests/QuestManager")]
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private QuestBase activeQuest;

        [SerializeField] private QuestsDatabase questDatabase;
    }
}
