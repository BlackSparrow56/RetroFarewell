using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Game.Events;
using Game.Events.Instructions.Enums;
using Utils;
using Utils.Extensions;
using TMPro;
using Zenject;

namespace Game.Lore
{
    [AddComponentMenu("Game/Lore/FurtherDestiny")]
    public class FurtherDestiny : MonoBehaviour
    {
        [SerializeField] private float transitionLength;
        [SerializeField] private float destinyLength;
        [SerializeField] private float betweenDelay;

        [SerializeField] private KeyCode skipKeyCode;

        [SerializeField] private UnityEvent end;

        [SerializeField] private List<Destiny> destinies;

        [SerializeField] private Image personImage;

        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;

        [SerializeField] private Transform content;

        private Executor _executor;

        [Inject]
        private void Construct(Executor executor)
        {
            _executor = executor;
        }

        public void Show()
        {
            StartCoroutine(ShowCoroutine());
        }

        public void SetDestiny(string name, string description)
        {
            destinies.FirstOrDefault(value => value.name == name).description = description;
        }

        public void SetDestiny(string nameAndDescription)
        {
            var parsed = nameAndDescription.Split('/');
            SetDestiny(parsed[0], parsed[1]);
        }

        private IEnumerator ShowCoroutine()
        {
            content.gameObject.SetActive(true);

            foreach (var destiny in destinies)
            {
                personImage.sprite = destiny.sprite;

                nameText.text = destiny.name;
                descriptionText.text = destiny.description;

                yield return Coroutines.Graduate(SetProgress, transitionLength);
                yield return new WaitForSeconds(destinyLength);
                yield return Coroutines.Graduate(SetProgress, transitionLength, true);

                yield return new WaitForSeconds(betweenDelay);

                void SetProgress(float progress)
                {
                    personImage.color = personImage.color.SetAlpha(progress);

                    nameText.alpha = progress;
                    descriptionText.alpha = progress;
                }
            }

            content.gameObject.SetActive(false);

            end.Invoke();
        }
    }
}
