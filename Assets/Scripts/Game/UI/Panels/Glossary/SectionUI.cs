using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.UI.Panels.Glossary
{
    [AddComponentMenu("Game/UI/Panels/Glossary/SectionUI")]
    public class SectionUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;

        public void Set(string name, Action action)
        {
            text.text = name;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action.Invoke);
        }
    }
}
