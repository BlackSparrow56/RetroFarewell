using UnityEngine;
using Game.Interactions;
using Utils;

namespace Game.Map
{
    [AddComponentMenu("Game/Map/Vanishing")]
    public class Vanishing : MonoBehaviour
    {
        [SerializeField] private float appearedAlpha;
        [SerializeField] private float disappearedAlpha;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.position.y > transform.position.y)
            {
                var controller = collision.gameObject.GetComponent<InteractController>();
                if (controller != null && controller.Name == "Player")
                {
                    Disappear();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.position.y > transform.position.y)
            {
                var controller = collision.gameObject.GetComponent<InteractController>();
                if (controller != null && controller.Name == "Player")
                {
                    Appear();
                }
            }
        }

        private void Appear()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetAlpha, 1f));
        }

        private void Disappear()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetAlpha, 1f, true));
        }

        private void SetAlpha(float progress)
        {
            var color = spriteRenderer.color;
            float alpha = Mathf.Lerp(disappearedAlpha, appearedAlpha, progress);

            spriteRenderer.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}
