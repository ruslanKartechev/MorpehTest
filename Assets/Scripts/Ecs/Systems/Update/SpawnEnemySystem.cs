using Data;
using Data.Prefabs;
using Ecs.Components;
using Ecs.Components.Command;
using Ecs.Components.View;
using Game.View;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Services.Parent;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class SpawnEnemySystem : UpdateSystem
    {
        [Inject] private IPrefabsRepository _prefabsRepository;
        [Inject] private IParentService _parentService;
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<SpawnEnemyComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                EnemyView prefab = null;
                var command = entity.GetComponent<SpawnEnemyComponent>();
                switch (command.EnemyType)
                {
                    case EEnemyType.Weak:
                        prefab = _prefabsRepository.GetPrefab<EnemyView>(PrefabNames.WeakEnemy);
                        break;
                    case EEnemyType.Middle:
                        prefab = _prefabsRepository.GetPrefab<EnemyView>(PrefabNames.NormalEnemy);
                        break;
                    case EEnemyType.Strong:
                        prefab = _prefabsRepository.GetPrefab<EnemyView>(PrefabNames.StrongEnemy);
                        break;
                }

                var viewInstance = UnityEngine.Object.Instantiate(prefab, command.Position, command.Rotation,
                    _parentService.DefaultParent);
                
                var enemyEntity = World.CreateEntity();
                enemyEntity.SetComponent(new EnemyComponent(command.EnemyType));
                enemyEntity.SetComponent(new PositionComponent(command.Position));
                enemyEntity.SetComponent(new RotationComponent(command.Rotation));
                enemyEntity.SetComponent(new HealthComponent(command.Health));
                enemyEntity.SetComponent(new StartHealthComponent(command.Health));
                enemyEntity.SetComponent(new DamageableComponent());
                enemyEntity.SetComponent(new SimpleViewComponent(viewInstance.transform));
                
                entity.RemoveComponent<SpawnEnemyComponent>();
            }
        }
        
    }
}