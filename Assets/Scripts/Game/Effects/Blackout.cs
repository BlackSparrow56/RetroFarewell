using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Extensions;

namespace Game.Effects
{
    [AddComponentMenu("Game/Effects/Blackout")]
    public class Blackout : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void Darken(float duration)
        {
            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                image.color = image.color.SetAlpha(progress);
            }
        }

        public void Lighten(float duration)
        {
            StopAllCoroutines();
            StartCoroutine(Coroutines.Graduate(SetProgress, duration));

            void SetProgress(float progress)
            {
                image.color = image.color.SetAlpha(1f - progress);
            }
        }
    }
}
