using Zenject;

namespace Installers
{
    public class EcsInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            
                        
        }

        private T CreateSystem<T>() where T : class, new()
        {
            var instance = new T();
            Container.Inject(instance);
            return instance;
        }
    }
}