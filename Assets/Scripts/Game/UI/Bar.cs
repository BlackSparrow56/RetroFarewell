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

        public void SetProgress(float barProgress)
        {
            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, 1f));

            void SetProgress(float progress)
            {
                image.fillAmount = progress;
            }
        }
    }
}