using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using Utils.Services;
using Zenject;

namespace Game.Locations
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField] private string currentLocationName;
        [SerializeField] private List<Location> locations;

        public Rect CurrentLocationRect => GetLocationByName(currentLocationName).rect;

        private AmbienceService _ambienceService;
        private PlayerController _playerController;

        [Inject]
        private void Construct(AmbienceService ambienceService, PlayerController playerController)
        {
            _ambienceService = ambienceService;
            _playerController = playerController;
        }

        public void MoveTo(string name)
        {
            var previous = GetLocationByName(currentLocationName);
            previous.location.SetActive(false);

            currentLocationName = name;

            var current = GetLocationByName(currentLocationName);
            if (current != null)
            {
                current.location.SetActive(true);

                _playerController.Camera.SetSize(current.cameraSize);
                _playerController.Camera.MoveInstantly();

                _ambienceService.SetClip(current.ambience, 1f);
            }
        }

        private Location GetLocationByName(string name)
        {
            return locations.FirstOrDefault(value => value.name == name);
        }

        private void Start()
        {
            MoveTo(currentLocationName);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            locations.ForEach(value => DrawLocationRect(value));

            static void DrawLocationRect(Location location)
            {
                Gizmos.DrawLine(new Vector2(location.rect.xMin, location.rect.yMin), new Vector2(location.rect.xMin, location.rect.yMax));
                Gizmos.DrawLine(new Vector2(location.rect.xMin, location.rect.yMax), new Vector2(location.rect.xMax, location.rect.yMax));
                Gizmos.DrawLine(new Vector2(location.rect.xMax, location.rect.yMax), new Vector2(location.rect.xMax, location.rect.yMin));
                Gizmos.DrawLine(new Vector2(location.rect.xMax, location.rect.yMin), new Vector2(location.rect.xMin, location.rect.yMin));
            }
        }
    }
}
