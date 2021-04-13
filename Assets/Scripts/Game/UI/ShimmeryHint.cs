using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI.Enums;
using TMPro;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/ShimmeryHint")]
    public class ShimmeryHint : MonoBehaviour
    {
        [SerializeField] private float frequency;
        [SerializeField] private EShimmeryType type;

        [SerializeField] private bool isActive;

        [SerializeField] private TMP_Text text;

        private float _startTime;

        public void SetActive(bool active)
        {
            isActive = active;
            if (!active)
            {
                text.alpha = 0f;
            }
            else
            {
                _startTime = Time.time;
            }
        }

        public void SetText(string text)
        {
            this.text.text = text;
        }

        private void Start()
        {
            SetActive(isActive);
        }

        private void Update()
        {
            if (isActive)
            {
                float sin = Mathf.Sin((Time.time - _startTime) * frequency);

                float alpha = sin;
                switch(type)
                {
                    case EShimmeryType.Clamped:
                        alpha = (sin + 1) / 2;
                        break;
                    case EShimmeryType.Absolute:
                        alpha = Mathf.Abs(sin);
                        break;
                }

                text.alpha = alpha;
            }
        }
    }
}
