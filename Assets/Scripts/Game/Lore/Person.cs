using UnityEngine;

namespace Game.Lore
{
    [CreateAssetMenu(menuName = "Lore/Person", fileName = "Person")]
    public class Person : ScriptableObject
    {
        [SerializeField] new private string name;

        [SerializeField] private Color nameColor; // Цвет имени в панели диалогов.

        public string Name => name;

        public Color NameColor => nameColor;
    }
}
