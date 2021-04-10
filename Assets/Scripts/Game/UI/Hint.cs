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
            float alpha = this.text.alpha;
            this.text.text = text;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                this.text.alpha = Mathf.Lerp(alpha, 1f, progress);
            }
        }
    }
}
