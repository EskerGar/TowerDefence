using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "SoInstaller", menuName = "SoInstaller")]
    public class SoInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private EnemySettings enemySettings;
        public override void InstallBindings()
        {
            Container.BindInstance(enemySettings);
        }
    }
}
