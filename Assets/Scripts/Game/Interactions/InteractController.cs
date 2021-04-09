using UnityEngine;

namespace Game.Interactions
{
    [AddComponentMenu("Game/Interactions/InteractController")]
    public class InteractController : MonoBehaviour
    {
        [SerializeField] new private string name;
        public string Name => name;
    }
}