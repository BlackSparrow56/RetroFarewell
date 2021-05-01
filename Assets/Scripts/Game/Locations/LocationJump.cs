using UnityEngine;
using Game.Player;
using Zenject;

namespace Game.Locations
{
    [AddComponentMenu("Game/Locations/LocationJump")]
    public class LocationJump : MonoBehaviour
    {
        [SerializeField] private string locationName;

        public void Jump()
        {
            var player = SceneContext.FindObjectOfType<PlayerController>();
            var manager = SceneContext.FindObjectOfType<LocationManager>();

            player.transform.position = transform.position;
            manager.MoveTo(locationName);
        }
    }
}
