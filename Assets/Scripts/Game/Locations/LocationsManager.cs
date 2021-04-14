using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Locations
{
    public class LocationsManager : MonoBehaviour
    {
        [SerializeField] private Location currentLocation;
        [SerializeField] private List<Location> locations;

        public Rect CurrentLocationRect => currentLocation.rect;

        public void MoveTo(string name)
        {
            currentLocation.location.SetActive(false);

            locations.Add(currentLocation);
            currentLocation = locations.FirstOrDefault(value => value.name == name);
            locations.Remove(currentLocation);

            currentLocation.location.SetActive(true);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector2(CurrentLocationRect.xMin, CurrentLocationRect.yMin), new Vector2(CurrentLocationRect.xMin, CurrentLocationRect.yMax));
            Gizmos.DrawLine(new Vector2(CurrentLocationRect.xMin, CurrentLocationRect.yMax), new Vector2(CurrentLocationRect.xMax, CurrentLocationRect.yMax));
            Gizmos.DrawLine(new Vector2(CurrentLocationRect.xMax, CurrentLocationRect.yMax), new Vector2(CurrentLocationRect.xMax, CurrentLocationRect.yMin));
            Gizmos.DrawLine(new Vector2(CurrentLocationRect.xMax, CurrentLocationRect.yMin), new Vector2(CurrentLocationRect.xMin, CurrentLocationRect.yMin));
        }
    }
}
