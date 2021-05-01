using UnityEngine;
using Utils;
using Utils.Enums;
using Zenject;

namespace Game.Saves
{
    [AddComponentMenu("Game/Saves/SaveManager")]
    public class SaveManager : MonoBehaviour
    {
        private readonly string defaultSaveDirectory = $"{Application.dataPath}/Save.binary";

        public void Save()
        {
            Serialization.Serialize(CreateSave(), defaultSaveDirectory, ESerializationMethod.Binary);
        }

        public void Load()
        {
            var save = Serialization.Deserialize<Save>(defaultSaveDirectory, ESerializationMethod.Binary);


        }

        private Save CreateSave()
        {
            var save = new Save();

            return save;
        }
    }
}
