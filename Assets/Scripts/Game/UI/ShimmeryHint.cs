using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/ShimmeryHint")]
    public class ShimmeryHint : MonoBehaviour
    {
        [SerializeField] private float frequency;

        [SerializeField] private bool abs;
        [SerializeField] private bool isActive;

        [SerializeField] private TMP_Text text;

        public void SetActive(bool active)
        {
            isActive = active;
            if (!active)
            {
                text.alpha = 0f;
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
                float alpha = Mathf.Sin(Time.time * frequency);
                text.alpha = abs ? Mathf.Abs(alpha) : alpha;
            }
        }
    }
}
