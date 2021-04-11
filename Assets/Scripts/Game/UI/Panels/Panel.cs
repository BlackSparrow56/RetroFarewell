using UnityEngine;
using UnityEngine.Events;
using Game.Player;
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
        [SerializeField] protected bool banPlayerMove;

        protected bool _opened = false;

        protected UIController _UIController;
        private PlayerController _playerController;

        [Inject]
        private void Construct(UIController UIController, PlayerController playerController)
        {
            _UIController = UIController;
            _playerController = playerController;
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

            if (banPlayerMove)
            {
                _playerController.Movement.CanMove = false;
            }
        }

        public virtual void Close()
        {
            _opened = false;
            panel.SetActive(false);
            closed.Invoke();

            if (banPlayerMove)
            {
                _playerController.Movement.CanMove = true;
            }
        }
    }
}
