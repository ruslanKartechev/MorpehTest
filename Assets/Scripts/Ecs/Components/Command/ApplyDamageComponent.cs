using Scellecs.Morpeh;

namespace Ecs.Components.Command
{
    public struct ApplyDamageComponent : IComponent
    {
        public float Value;

        public ApplyDamageComponent(float value)
        {
            Value = value;
        }
    }
}