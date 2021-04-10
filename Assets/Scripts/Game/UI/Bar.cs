using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/Bar")]
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image image;

        [SerializeField] private Gradient gradient;

        private float _progress;
        public float Progress => _progress;

        public void SetProgress(float barProgress)
        {
            float tempProgress = _progress;

            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, 1f));

            void SetProgress(float progress)
            {
                float currentProgress = Mathf.Lerp(tempProgress, progress, progress);

                image.fillAmount = currentProgress;
                _progress = currentProgress;
            }
        }
    }
}