using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Components
{
    public struct PositionComponent : IComponent
    {
        public PositionComponent(Vector3 value)
        {
            Value = value;
        }

        public Vector3 Value;
    }
}