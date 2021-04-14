using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Locations;
using Utils.Extensions;
using Zenject;

namespace Game.Player
{
    [AddComponentMenu("Game/Player/PlayerCamera")]
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private float defaultSize;
        [SerializeField] private float sizeMultiplier;

        [SerializeField] private Transform player;
        [SerializeField] new private Camera camera;

        private LocationsManager _locationsManager;

        [Inject]
        private void Construct(LocationsManager locationsManager)
        {
            _locationsManager = locationsManager;
        }

        private void Move()
        {
            var delta = player.position - transform.position;
            delta.z = 0f;

            transform.Translate(delta * speed * Time.deltaTime);

            camera.orthographicSize = defaultSize + sizeMultiplier * delta.magnitude;
        }

        private void Clamp()
        {
            if (!_locationsManager.CurrentLocationRect.ContainsEntirely(camera.GetWorldRect()))
            {
                Vector3 clampedPosition = camera.GetWorldRect().ClampedInRectCenter(_locationsManager.CurrentLocationRect);
                clampedPosition.z = camera.transform.position.z;

                camera.transform.position = clampedPosition;
            }
        }

        private void Update()
        {
            Move();
            Clamp();
        }
    }
}
