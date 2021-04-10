using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
using Game.UI.Panels;
using Zenject;

namespace Game.UI
{
    [AddComponentMenu("Game/UI/UIController")]
    public class UIController : MonoBehaviour
    {
        [SerializeField] private List<BindPanel> panels;

        public List<BindPanel> Panels => panels;

        private PlayerController _playerController;

        public bool CanOpenPanel
        {
            get;
            set;
        }

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public Panel GetPanelByName(string name)
        {
            return panels.FirstOrDefault(value => value.name == name).panel;
        }

        public void CloseBeside(Panel beside)
        {
            panels.Where(value => value.panel != beside).ToList().ForEach(value => value.panel.Close());
        }

        private void Update()
        {
            if (CanOpenPanel)
            {
                foreach (var panel in panels)
                {
                    if (Input.GetKeyDown(panel.keyCode))
                    {
                        panel.panel.Toggle(out bool opened);

                        _playerController.Movement.CanMove = !opened;
                    }
                }
            }
        }
    }
}
