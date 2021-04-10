using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Game.UI.Panels
{
    [AddComponentMenu("Game/UI/Panels/Panel")]
    public class Panel : MonoBehaviour
    {
        [SerializeField] protected GameObject panel;

        [SerializeField] protected UnityEvent opened;
        [SerializeField] protected UnityEvent closed;

        [SerializeField] protected bool closeAllOther;

        protected bool _opened = false;

        protected UIController _UIController;

        [Inject]
        private void Construct(UIController UIController)
        {
            _UIController = UIController;
        }

        public virtual void Toggle(out bool opened)
        {
            opened = !_opened;
            Toggle();
        }

        public virtual void Toggle()
        {
            if (!_opened)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public virtual void Open()
        {
            _opened = true;
            panel.SetActive(true);
            opened.Invoke();

            if (closeAllOther)
            {
                _UIController.CloseBeside(this);
            }
        }

        public virtual void Close()
        {
            _opened = false;
            panel.SetActive(false);
            closed.Invoke();
        }
    }
}
