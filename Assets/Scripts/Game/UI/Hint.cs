using UnityEngine;
using Utils;
using TMPro;

namespace Game.UI
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Show(string text, float duration)
        {
            this.text.text = text;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                this.text.alpha = progress;
            }
        }
    }
}
