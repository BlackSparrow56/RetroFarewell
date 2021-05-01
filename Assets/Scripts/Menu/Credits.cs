using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.UI;
using Game.Events;
using Game.Events.Instructions.Enums;
using Utils;
using Utils.Extensions;
using TMPro;
using Zenject;

namespace Menu
{
    [AddComponentMenu("Menu/Credits")]
    public class Credits : MonoBehaviour
    {
        [SerializeField] private float maxCreditsY;
        [SerializeField] private float minCreditsY;

        [SerializeField] private float disappearingDuration;
        [SerializeField] private float flowingDuration;
        [SerializeField] private float hidingDuration;

        [SerializeField] private KeyCode skipKeyCode;

        [SerializeField] private Image background;
        [SerializeField] private List<TMP_Text> texts;

        [SerializeField] private TMP_Text credits;

        [SerializeField] private ShimmeryHint hint;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        public void Show()
        {
            StopAllCoroutines();
            StartCoroutine(ShowCoroutine());
        }

        private void Hide()
        {
            StartCoroutine(HideCoroutine());
        }

        private IEnumerator ShowCoroutine()
        {
            hint.SetText($"Нажмите <b><color=#FFC864>{skipKeyCode}</color></b>, чтобы пропустить титры.");

            credits.alpha = 1f;
            credits.transform.localPosition = new Vector3(credits.transform.localPosition.x, maxCreditsY, credits.transform.localPosition.z);

            float temp = background.color.a;

            yield return Coroutines.Graduate(SetBackgroundAlpha, disappearingDuration, false, null, OnDisappear);
            var instruction = _executor.AddKeyInstruction(skipKeyCode, EKeyState.Pushed, Hide, true);
            yield return Coroutines.Graduate(SetProgress, flowingDuration);
            _executor.RemoveKeyInstruction(instruction);

            yield return HideCoroutine();

            void SetProgress(float progress)
            {
                float y = Mathf.Lerp(minCreditsY, maxCreditsY, progress);
                credits.transform.localPosition = new Vector3(credits.transform.localPosition.x, y, credits.transform.localPosition.z);
            }

            void SetBackgroundAlpha(float progress)
            {
                float current = Mathf.Lerp(temp, 0, progress);

                background.color = background.color.SetAlpha(current);
                texts.ForEach(value => value.alpha = current);
            }

            void OnDisappear()
            {
                texts.ForEach(value => value.gameObject.SetActive(false));
                hint.SetActive(true);
            }
        }

        private IEnumerator HideCoroutine()
        {
            texts.ForEach(value => value.gameObject.SetActive(true));

            float tempCredits = credits.alpha;
            float tempBg = background.color.a;

            hint.SetActive(false);
            yield return Coroutines.Graduate(SetCreditsAplha, hidingDuration / 2);
            yield return Coroutines.Graduate(SetBackgroundAlpha, hidingDuration / 2);

            void SetCreditsAplha(float progress)
            {
                float current = Mathf.Lerp(tempCredits, 0f, progress);
                credits.alpha = current;
            }

            void SetBackgroundAlpha(float progress)
            {
                float current = Mathf.Lerp(tempBg, 1f, progress);

                background.color = background.color.SetAlpha(current);
                texts.ForEach(value => value.alpha = current);
            }
        }
    }
}
