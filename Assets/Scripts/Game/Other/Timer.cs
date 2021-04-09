using UnityEngine;

namespace Game.Other
{
    [AddComponentMenu("Game/Other/Timer")]
    public class Timer : MonoBehaviour
    {
        private float time = 0f;

        public void End(out float time)
        {
            time = this.time;
            this.time = 0f;
        }

        private void Start()
        {
            time = PlayerPrefs.GetFloat("Time");
        }

        private void Update()
        {
            time += Time.deltaTime;
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetFloat("Time", time);
        }
    }
}
