using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Game.UI;
using Game.Events;
using Game.Events.Instructions;
using Game.Events.Instructions.Enums;
using Utils;
using Utils.Extensions;
using Zenject;

namespace Splash
{
    [AddComponentMenu("Splash/Slide")]
    public class SplashController : MonoBehaviour
    {
        [SerializeField] private Image splashImage;
        [SerializeField] private ShimmeryHint hint;

        [SerializeField] private SplashSettings settings;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        private void AppearImage()
        {
            StartCoroutine(Coroutines.Graduate(SetProgress, 2.5f));

            void SetProgress(float progress)
            {
                splashImage.color = splashImage.color.SetAlpha(progress);
            }
        }

        private void AppearHint()
        {
            hint.SetText($"Нажмите {$"<b><color={settings.keyCodeColor.ToHexadecimal()}>{settings.keyCode}</color></b>"}, чтобы перейти в меню.");
            hint.SetActive(true);

            _executor.AddKeyInstruction(KeyCode.Space, EKeyState.Pushed, OpenMenu, true);

            static void OpenMenu()
            {
                SceneManager.LoadScene("Menu");
            }
        }

        private void Start()
        {
            splashImage.color = splashImage.color.SetAlpha(0f);
            AppearImage();

            var queue = new InstructionsQueue();
            queue.Add(new ConditionInstruction(() => splashImage.color.a == 1f, AppearHint));

            _executor.AddQueue(queue);
        }
    }
}
