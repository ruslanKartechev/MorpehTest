using Scellecs.Morpeh;
using UniRx;

namespace Ecs.Components
{
    public struct DamageRangeComponent : IComponent
    {
        public ReactiveProperty<float> Property;

        public DamageRangeComponent(float value)
        {
            Property = new ReactiveProperty<float>();
            Property.Value = value;
        }
    }
}