using UnityEngine;
using Game.Events;
using Zenject;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Settings/Installer", fileName = "Installer")]
    public class Installer : ScriptableObjectInstaller<Installer>
    {
        public Databases databases;

        public void Execute(string text)
        {
            Debug.Log($"Executed: {text}");
        }

        public override void InstallBindings()
        {
            Container.BindInstance(databases);
        }
    }
}