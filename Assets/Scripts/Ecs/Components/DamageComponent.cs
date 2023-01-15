using Scellecs.Morpeh;
using UniRx;

namespace Ecs.Components
{
    public struct DamageComponent : IComponent
    {
        public ReactiveProperty<float> Property;

        public DamageComponent(float value)
        {
            Property = new ReactiveProperty<float>();
            Property.Value = value;
        }

        
    }
}