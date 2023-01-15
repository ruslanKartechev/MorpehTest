using Scellecs.Morpeh;

namespace Ecs.Components
{
    public struct StartHealthComponent : IComponent
    {
        public StartHealthComponent(float value)
        {
            Value = value;
        }

        public float Value;
        
    }
}