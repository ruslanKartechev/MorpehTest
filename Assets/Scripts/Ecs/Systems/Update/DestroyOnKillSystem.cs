using Ecs.Components;
using Ecs.Components.Command;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Ecs.Systems
{
    public class DestroyOnKillSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<KillComponent>().Without<IsDestroyedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.RemoveComponent<KillComponent>();
                entity.AddComponent<IsDestroyedComponent>();
            }
        }
    }
}