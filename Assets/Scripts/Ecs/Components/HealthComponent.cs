using Scellecs.Morpeh;

namespace Ecs.Components
{
    public struct HealthComponent : IComponent
    {
        public float Value;

        public HealthComponent(float value)
        {
            Value = value;
        }
    }
}