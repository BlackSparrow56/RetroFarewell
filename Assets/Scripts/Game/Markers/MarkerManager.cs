using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Markers.Enums;
using Utils;
using Utils.Geometry;
using Utils.Extensions;

namespace Game.Markers
{
    [AddComponentMenu("Game/Markers/MarkerManager")]
    public class MarkerManager : MonoBehaviour
    {
        [SerializeField] private Vector2 markersIndent;

        [SerializeField] private List<EnumValuePair<EMarkerType, GameObject>> prefabs;

        [SerializeField] private Transform markersAxis;
        [SerializeField] new private Camera camera;

        private readonly List<MarkerBase> _markers = new List<MarkerBase>();

        private Rect MarkersWorldRect
        {
            get
            {
                var position = camera.ScreenToWorldPoint(markersIndent / 2);
                var size = camera.ScreenToWorldPoint(camera.pixelRect.size) - camera.ScreenToWorldPoint(markersIndent);

                return new Rect(position, size);
            }
        }

        public void SetMarkersActive(bool active)
        {
            markersAxis.gameObject.SetActive(active);
        }

        public ActionMarker CreateActionMarker(Transform target, Sprite sprite, Action action, bool selfDestroy = true)
        {
            var marker = Instantiate(GetPrefabByType(EMarkerType.Action), markersAxis);
            var component = marker.GetComponent<ActionMarker>();

            component.Target = target;
            component.Sprite = sprite;
            component.SelfDestroy = selfDestroy;
            component.onMarkerDisappear += action.Invoke;
            if (selfDestroy)
            {
                component.onMarkerDisappear += SelfDestroy;

                void SelfDestroy()
                {
                    _markers.Remove(component);
                    Destroy(component.gameObject);
                }
            }

            _markers.Add(component);
            return component;
        }

        public PlaceMarker CreatePlaceMarker(Transform target, Sprite sprite)
        {
            var marker = Instantiate(GetPrefabByType(EMarkerType.Place), markersAxis);
            var component = marker.GetComponent<PlaceMarker>();

            component.Target = target;
            component.Sprite = sprite;

            _markers.Add(component);
            return component;
        }

        public void RemoveMarker(MarkerBase marker)
        {
            if (marker != null)
            {
                Destroy(marker.gameObject);
            }

            _markers.Remove(marker);
        }

        private GameObject GetPrefabByType(EMarkerType type)
        {
            return prefabs.FirstOrDefault(value => value.@enum == type).value;
        }

        private Vector2 StationOverlay(Vector2 targetPosition, Vector2 size)
        {
            var targetScreenPosition = camera.WorldToScreenPoint(targetPosition);
            Vector2 leftDown = Vector2.zero + size / 2;
            Vector2 rightUp = (Vector2) camera.ViewportToScreenPoint(Vector2.one) - size / 2;
            return TryFindCrossWithScreenEdge(targetScreenPosition, leftDown, rightUp);
        }

        private Vector2 TryFindCrossWithScreenEdge(Vector2 point, Vector2 leftDown, Vector2 rightUp)
        {
            Vector2 center = leftDown + (rightUp - leftDown) / 2;
            var leftUp = new Vector2(leftDown.x, rightUp.y);
            var rightDown = new Vector2(rightUp.x, leftDown.y);
            var edges = new List<Line>
            {
                new Line() { p1 = leftUp, p2 = rightUp },
                new Line() { p1 = rightUp, p2 = rightDown },
                new Line() { p1 = rightDown, p2 = leftDown },
                new Line() { p1 = leftDown, p2 = leftUp }
            };

            foreach (var edge in edges)
            {
                if (LineSegment.AreCrossing(point, center, edge.p1, edge.p2, out var pointCross))
                {
                    return pointCross;
                }
            }

            return point;
        }

        private void Update()
        {
            var incoming = new List<MarkerBase>(_markers);

            foreach (var marker in incoming)
            {
                var delta = (Vector2)marker.Target.transform.position - camera.GetWorldCenter();
                var range = delta.magnitude;

                marker.SetRange(range);
                marker.transform.position = StationOverlay(marker.Target.position, ((RectTransform) marker.transform).sizeDelta / 2 + markersIndent);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            var corners = MarkersWorldRect.GetCorners();

            Gizmos.DrawLine(corners[0], corners[1]);
            Gizmos.DrawLine(corners[1], corners[2]);
            Gizmos.DrawLine(corners[2], corners[3]);
            Gizmos.DrawLine(corners[3], corners[0]);
        }

        private class Line
        {
            public Vector2 p1, p2;
        }
    }
}
