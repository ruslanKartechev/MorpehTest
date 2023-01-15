using Data.Level;
using Ecs.Components;
using Ecs.Components.Command;
using Ecs.Other;
using Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Services.Parent;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class LoadLevelSystem : UpdateSystem
    {
        [Inject] private ILevelRepository _levelRepository;
        [Inject] private IParentService _parentService;
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<LoadLevelComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var index = entity.GetComponent<LoadLevelComponent>().LevelIndex;
                var prefab = _levelRepository.GetPrefab(index);
                var instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, null);
                _parentService.DefaultParent = instance.transform;
          
                foreach (var spawnData in instance.spawnPoints)
                {
                    var commandEntity = World.CreateEntity();
                    commandEntity.AddComponent<SpawnEnemyComponent>();
                    var spawnCommand = new SpawnEnemyComponent(spawnData.SpawnPoint.position,
                        spawnData.SpawnPoint.rotation,
                        spawnData.EnemyType,
                        spawnData.Health);
                    commandEntity.SetComponent(spawnCommand);
                }

                var spawnPlayerCommand = new SpawnPlayerComponent(instance.PlayerSpawnData);
                    GamePool.PlayerEntity.SetComponent(spawnPlayerCommand);
                
                var cameraEntity = GamePool.CameraEntity;
                ref var pos = ref cameraEntity.GetComponent<PositionComponent>();
                ref var rot = ref cameraEntity.GetComponent<RotationComponent>();
                pos.Value = instance.cameraPosition.position;
                rot.Value = instance.cameraPosition.rotation;
                
                entity.RemoveComponent<LoadLevelComponent>();
            }
        }
        
        
    }
}