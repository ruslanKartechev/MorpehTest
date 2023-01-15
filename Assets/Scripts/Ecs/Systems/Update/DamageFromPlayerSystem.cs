using System.Collections.Generic;
using Data;
using Ecs.Components;
using Ecs.Components.Command;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class DamageFromPlayerSystem : UpdateSystem
    {
        private Filter _filter;
        [Inject] private IGlobalSettings _globalSettings;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>()
                .With<HealthComponent>()
                .With<DamageableComponent>()
                .Without<KillComponent>()
                .Without<IsDestroyedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = World.Filter.With<PlayerComponent>().First();
       
            var playerPos = player.GetComponent<PositionComponent>().Value;
            var damageAmount = player.GetComponent<DamageComponent>().Property.Value;
            var maxDistance2 = Mathf.Pow( player.GetComponent<DamageRangeComponent>().Property.Value, 2) ;
            
            var distanceData = new List<Data>();
            foreach (var entity in _filter)
            {
                var pos = entity.GetComponent<PositionComponent>().Value;
                var d2 = (pos - playerPos).sqrMagnitude;
                distanceData.Add(new Data(entity, d2));
            }
            distanceData.Sort( (x,y) => x.Distance2.CompareTo(y.Distance2));
            
            var damagedCount = 0;
            var maxDamageCount = _globalSettings.MaxDamageCount;
            foreach (var data in distanceData)
            {
                if (data.Distance2 <= maxDistance2)
                {
                    data.Entity.SetComponent(new ApplyDamageComponent(damageAmount * deltaTime));
                    damagedCount++;
                    if (damagedCount >= maxDamageCount)
                    {
                        break;
                    }
                }
            }
            // Debug.Log($"total count damaged: {damagedCount}");
        }


        private class Data
        {
            public float Distance2;
            public Entity Entity;

            public Data(Entity entity, float distance2)
            {
                Entity = entity;
                Distance2 = distance2;
            }
        }
    }
}