using System;
using System.Collections.Generic;

namespace Game.Dialogues.Structs
{
    [Serializable]
    public struct Replica
    {
        /// <summary>
        /// Имя персонажа, которому принадлежит реплика. Указывается в тексте, находится в базе данных и исходя из значения устанавливается цвет имени в панели диалогов.
        /// </summary>
        public string name;

        /// <summary>
        /// Содержимое реплики.
        /// </summary>
        public string text;

        public int node;
        public List<Answer> answers;
    }
}
