using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Game.Dialogues;

namespace Game.Temp
{
    public class Serializer : MonoBehaviour
    {
        [SerializeField] private Dialogue dialogue;

        [ContextMenu("Serialize")]
        public void SerializeDialogue()
        {
            /*
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(@"C:\Users\Msey\Desktop\GameState.dat", FileMode.Create))
            {
                formatter.Serialize(stream, dialogue);
            }
            */

            using (StreamWriter stream = new StreamWriter(@"C:\Users\Admin\Desktop\Temporary Folder\Dialogue.dat"))
            {
                stream.Write(JsonUtility.ToJson(dialogue, true));
                Debug.Log($"Serialized to JSON!");
            }
        }

        [ContextMenu("Deserialize")]
        public void DeserializeDialogue()
        {
            using (StreamReader stream = new StreamReader(@"C:\Users\Admin\Desktop\Temporary Folder\Dialogue.dat"))
            {
                dialogue = JsonUtility.FromJson<Dialogue>(stream.ReadToEnd());
                Debug.Log($"Deserialized from JSON!");
            }
        }
    }
}
