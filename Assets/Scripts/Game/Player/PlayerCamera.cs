using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Update()
        {
            var delta = player.position - transform.position;
            delta.z = 0f;

            transform.Translate(delta * speed * Time.deltaTime);

            camera.orthographicSize = defaultSize + sizeMultiplier * delta.magnitude;
        }
    }
}
