using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Settings
{
    [CreateAssetMenu(menuName = "Settings/Installer", fileName = "Installer")]
    public class Installer : ScriptableObjectInstaller<Installer>
    {
        public Databases databases;

        public override void InstallBindings()
        {
            Container.BindInstance(databases).AsSingle();
        }
    }
}