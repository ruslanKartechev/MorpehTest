using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Components.View
{
    public struct SimpleViewComponent : IComponent
    {
        public SimpleViewComponent(Transform viewTransform)
        {
            ViewTransform = viewTransform;
        }

        public Transform ViewTransform;
        
    }
}