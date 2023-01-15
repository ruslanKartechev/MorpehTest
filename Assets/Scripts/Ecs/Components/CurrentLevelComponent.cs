using Scellecs.Morpeh;

namespace Ecs.Components
{
    public struct CurrentLevelComponent : IComponent
    {
        public int Value;

        public CurrentLevelComponent(int value)
        {
            Value = value;
        }
    }
}