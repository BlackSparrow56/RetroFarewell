using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.Events
{
    [AddComponentMenu("Menu/Events/MenuEvents")]
    public class MenuActions : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("Game");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
