using Data.Prefabs;
using Ecs.Components.Command;
using Ecs.Other;
using Game.View;
using GameUI;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Services.Parent;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class SpawnPlayerSystem : UpdateSystem
    {
        private Filter _filter;
        [Inject] private IParentService _parentService;
        [Inject] private IPrefabsRepository _prefabsRepository;
        [Inject] private IPlayerHoodUI _playerHoodUI;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<SpawnPlayerComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var command = ref entity.GetComponent<SpawnPlayerComponent>();
                var prefab = _prefabsRepository.GetPrefab<PlayerView>(PrefabNames.Player);
                var data = command.Data;
                var instance = Object.Instantiate(prefab, data.Point.position, data.Point.rotation,
                    _parentService.DefaultParent);

                var characterEntity = EntityCreator.CreatePlayerCharacter(World,
                    instance,
                    data.Point.position,
                    data.Point.rotation,
                    data.Stats.MoveSpeed,
                    data.Stats.DamageRadius,
                    data.Stats.Damage
                );
                _playerHoodUI.Init(characterEntity, GamePool.PlayerEntity);
                entity.RemoveComponent<SpawnPlayerComponent>();
            }
        }
    }
}