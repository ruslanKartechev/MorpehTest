using Scellecs.Morpeh;
using UniRx;

namespace Ecs.Components
{
    public struct MoveSpeedComponent : IComponent
    {
        public ReactiveProperty<float> Property;

        public MoveSpeedComponent(float value)
        {
            Property = new ReactiveProperty<float>(value);
        }

    }
}