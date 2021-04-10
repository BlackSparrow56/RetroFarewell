using System;
using Game.Databases;

namespace Game.Settings
{
    [Serializable]
    public class Databases
    {
        public AttackAnswersDatabase attackAnswersDatabase;
        public DialoguesDatabase dialoguesDatabase;
        public ItemsDatabase itemsDatabase;
        public QuestsDatabase questsDatabase;
    }
}
