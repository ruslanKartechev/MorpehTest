using Ecs.Components;
using Ecs.Components.View;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Ecs.Systems
{
    public class UpdateViewTransformSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<SimpleViewComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var view = ref entity.GetComponent<SimpleViewComponent>();
                var t = view.ViewTransform;
                ref var pos = ref entity.GetComponent<PositionComponent>();
                ref var rot = ref entity.GetComponent<RotationComponent>();

                t.rotation = rot.Value;
                t.position = pos.Value;
                // Debug.Log($"moving to: {pos.Value}");
            }
        }
    }
}