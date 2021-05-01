using UnityEngine;

namespace Game.Settings
{
    [AddComponentMenu("Game/Settings/ScreenSettings")]
    public class ScreenSettings : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F12))
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
        }
    }
}
