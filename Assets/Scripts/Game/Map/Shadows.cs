using UnityEngine;
using Game.Player;
using Game.Interactions;
using Utils;

namespace Game.Map
{
    [AddComponentMenu("Game/Map/Shadows")]
    public class Shadows : MonoBehaviour
    {
        [SerializeField] private float duration;

        [SerializeField] private Color defaultColor;
        [SerializeField] private Color shadowedColor;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var controller = collision.gameObject.GetComponent<InteractController>();
            if (controller.Name == "Player")
            {
                var player = collision.gameObject.GetComponent<PlayerController>();
                var tempColor = player.SpriteRenderer.color;

                StopAllCoroutines();
                StartCoroutine(Coroutines.Graduate(SetProgress, duration));

                void SetProgress(float progress)
                {
                    player.SpriteRenderer.color = Color.Lerp(tempColor, shadowedColor, progress);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var controller = collision.gameObject.GetComponent<InteractController>();
            if (controller.Name == "Player")
            {
                var player = collision.gameObject.GetComponent<PlayerController>();
                var tempColor = player.SpriteRenderer.color;

                StopAllCoroutines();
                StartCoroutine(Coroutines.Graduate(SetProgress, duration));

                void SetProgress(float progress)
                {
                    player.SpriteRenderer.color = Color.Lerp(tempColor, defaultColor, progress);
                }
            }
        }
    }
}
