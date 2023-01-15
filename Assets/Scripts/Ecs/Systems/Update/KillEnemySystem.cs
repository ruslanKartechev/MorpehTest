using System;
using Data;
using Ecs.Components;
using Ecs.Components.Command;
using Ecs.Other;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Sirenix.OdinValidator.Editor;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class KillEnemySystem : UpdateSystem
    {
        private Filter _filter;
        [Inject] private IGlobalSettings _globalSettings;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<KillComponent>().With<EnemyComponent>().Without<IsDestroyedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var killCount = ref GamePool.PlayerEntity.GetComponent<KillCountComponent>();
                killCount.Property.Value++;
                var y = entity.GetComponent<PositionComponent>().Value.y;
                var pos = GetPos(y);
                var type = entity.GetComponent<EnemyComponent>().Value;
                var health = entity.GetComponent<StartHealthComponent>().Value;
                World.CreateEntity().SetComponent(new SpawnEnemyComponent(pos, Quaternion.identity, type,  health));
            }
        }

        private Vector3 GetPos(float y)
        {
            var rad = _globalSettings.SpawnRad;
            var x = UnityEngine.Random.Range(-rad, rad);
            var z = UnityEngine.Random.Range(-rad, rad);
            return new Vector3(x, y, z);
        }
    }
}