using Ecs.Components;
using Ecs.Systems;
using Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine.Windows.Speech;
using Zenject;

namespace Ecs.Other
{
    public class EcsInit
    {
        public static void Init(DiContainer container)
        {
            var world = World.Create();
            world.UpdateByUnity = true;
            var player = EntityCreator.CreatePlayerEntity(world);
            GamePool.PlayerEntity = player;
            
            
            var mainGroup = world.CreateSystemsGroup();
            // init
            var camInit = MakeSystem<InitCameraSystem>(container);
            mainGroup.AddInitializer(camInit);
            var gameInit = MakeSystem<InitGameSystem>(container);
            mainGroup.AddInitializer(gameInit);
            // update
            MakeUpdateSystem<LoadLevelSystem>(container, mainGroup);
            MakeUpdateSystem<SpawnEnemySystem>(container, mainGroup);
            MakeUpdateSystem<SpawnPlayerSystem>(container, mainGroup);
            MakeUpdateSystem<CaptureInputSystem>(container, mainGroup);
            MakeUpdateSystem<MovePlayerSystem>(container, mainGroup);
            MakeUpdateSystem<DamageFromPlayerSystem>(container, mainGroup);
            MakeUpdateSystem<ApplyDamageSystem>(container, mainGroup);
            MakeUpdateSystem<KillEnemySystem>(container, mainGroup);
            MakeUpdateSystem<DestroyOnKillSystem>(container, mainGroup);
            MakeUpdateSystem<ApplyRandomBoostSystem>(container, mainGroup);
            MakeUpdateSystem<DestroyViewSystem>(container, mainGroup);
            
            var updateTranformView = MakeSystem<UpdateViewTransformSystem>(container);
            mainGroup.AddSystem(updateTranformView);
            
            world.AddSystemsGroup(0, mainGroup);
        }

        private static T MakeUpdateSystem<T>(DiContainer container, SystemsGroup group)
            where T : UpdateSystem, new()
        {
            var instance = new T();
            container.Inject(instance);
            group.AddSystem(instance);
            return instance;   
        }

        private static T MakeSystem<T>(DiContainer container) where T : class, new()
        {
            var instance = new T();
            container.Inject(instance);
            return instance;
        }
    }
    
}