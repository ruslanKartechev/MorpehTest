using Ecs.Components;
using Ecs.Components.View;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Ecs.Systems
{
    public class DestroyViewSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<IsDestroyedComponent>().With<SimpleViewComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var view = ref entity.GetComponent<SimpleViewComponent>();
                Object.Destroy(view.ViewTransform.gameObject);
                entity.RemoveComponent<IsDestroyedComponent>();
                entity.Dispose();
            }
        }
    }
}