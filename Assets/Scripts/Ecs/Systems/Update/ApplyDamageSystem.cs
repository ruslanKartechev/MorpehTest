using System.Runtime.Serialization;
using Ecs.Components;
using Ecs.Components.Command;
using Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Ecs.Systems
{
    public class ApplyDamageSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<ApplyDamageComponent>()
                .With<HealthComponent>()
                .Without<KillComponent>()
                .Without<IsDestroyedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var damage = ref entity.GetComponent<ApplyDamageComponent>();
                ref var healthComp = ref entity.GetComponent<HealthComponent>();
                healthComp.Value -= damage.Value;
                if (healthComp.Value <= 0)
                {
                    entity.AddComponent<KillComponent>();
                }
                entity.RemoveComponent<ApplyDamageComponent>();
            }
        }
    }
}