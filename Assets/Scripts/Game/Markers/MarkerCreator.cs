using UnityEngine;
using UnityEngine.Events;
using Game.Markers.Enums;
using Zenject;

namespace Game.Markers
{
    [AddComponentMenu("Game/Markers/MarkerCreator")]
    public class MarkerCreator : MonoBehaviour
    {
        [SerializeField] private EMarkerType type;

        [SerializeField] private Sprite sprite;
        [SerializeField] private bool selfDestroy;

        [SerializeField] private UnityEvent unityEvent;

        private MarkerBase _marker;

        private MarkerManager _markersManager;

        [Inject]
        private void Construct(MarkerManager markerManager)
        {
            _markersManager = markerManager;
        }

        private void OnEnable()
        {
            switch (type)
            {
                case EMarkerType.Action:
                    _marker = _markersManager.CreateActionMarker(transform, sprite, unityEvent.Invoke, selfDestroy);
                    break;
                case EMarkerType.Place:
                    _marker = _markersManager.CreatePlaceMarker(transform, sprite);
                    break;
            }
        }

        private void OnDisable()
        {
            _markersManager.RemoveMarker(_marker);
            _marker = null;
        }
    }
}
