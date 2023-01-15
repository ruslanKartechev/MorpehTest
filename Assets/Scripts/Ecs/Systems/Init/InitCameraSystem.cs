using Ecs.Components;
using Ecs.Components.View;
using Ecs.Other;
using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Systems
{
    public class InitCameraSystem : IInitializer
    {
        public void Dispose()
        {
        }

        public void OnAwake()
        {
            var camera = World.CreateEntity();

            var viewComp = new SimpleViewComponent(GamePool.CameraView.transform);
            camera.SetComponent(viewComp);
            camera.AddComponent<CameraComponent>();
            camera.AddComponent<PositionComponent>();
            camera.AddComponent<RotationComponent>();
            GamePool.CameraEntity = camera;
        }

        public World World { get; set; }
    }
}