using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Components
{
    public struct RotationComponent : IComponent
    {
        public Quaternion Value;

        public RotationComponent(Quaternion value)
        {
            Value = value;
        }
    }
}