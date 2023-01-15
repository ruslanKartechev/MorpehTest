using System.ComponentModel;
using System.Security.Cryptography;
using Data;
using Ecs.Components;
using Ecs.Components.Command;
using Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Ecs.Systems
{
    public class ApplyRandomBoostSystem : UpdateSystem
    {
        private Filter _filter;
        [Inject] private IBoostService _boostService;   

        public override void OnAwake()
        {
            _filter = World.Filter.With<MoveSpeedComponent>()
                .With<DamageRangeComponent>()
                .With<DamageComponent>()
                .Without<KillComponent>()
                .With<ApplyRandomBoostComponent>()
                .Without<IsDestroyedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var boost = _boostService.GetRandomBoost();
                Dbg.LogGreen($"Applied boost type: {boost.Type.ToString()}");
                switch (boost.Type)
                {
                    case EBoostType.Damage:
                        ref var damage = ref entity.GetComponent<DamageComponent>();
                        damage.Property.Value += boost.Step;
                        break;
                    case EBoostType.DamageRadius:
                        ref var radius = ref entity.GetComponent<DamageRangeComponent>();
                        radius.Property.Value += boost.Step;
                        break;
                    case EBoostType.Speed:
                        ref var speed = ref entity.GetComponent<MoveSpeedComponent>();
                        speed.Property.Value += boost.Step;
                        break;
                }
                
                entity.RemoveComponent<ApplyRandomBoostComponent>();
            }
        }
    }
}