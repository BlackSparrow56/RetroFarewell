using UnityEngine;
using TMPro;

namespace Game.UI.Panels.Dialogue
{
    public abstract class DialogueElement : MonoBehaviour
    {
        [SerializeField] protected TMP_Text contentText;
        [SerializeField] protected LinkExecutor linkExecutor;

        public void Set(string text)
        {
            contentText.text = text;
        }
    }
}
