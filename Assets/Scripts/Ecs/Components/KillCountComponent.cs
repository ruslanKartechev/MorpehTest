using Scellecs.Morpeh;
using UniRx;

namespace Ecs.Components
{
    public struct KillCountComponent : IComponent
    {
        public ReactiveProperty<int> Property;

        public KillCountComponent(int val)
        {
            Property = new ReactiveProperty<int>();
            Property.Value = val;
        }
    }
}