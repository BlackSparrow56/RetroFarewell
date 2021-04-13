using UnityEngine;
using Utils;
using TMPro;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/Hint")]
    public class Hint : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Show(string text, float duration)
        {
            this.text.text = text;
            Show(duration);
        }

        public void Show(float duration)
        {
            float alpha = text.alpha;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                text.alpha = Mathf.Lerp(alpha, 1f, progress);
            }
        }

        public void Hide(float duration)
        {
            float alpha = text.alpha;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                text.alpha = Mathf.Lerp(alpha, 0f, progress);
            }
        }
    }
}
