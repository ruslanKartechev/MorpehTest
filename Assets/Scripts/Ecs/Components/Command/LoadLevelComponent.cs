using Scellecs.Morpeh;

namespace Ecs.Components.Command
{
    public struct LoadLevelComponent : IComponent
    {
        public int LevelIndex;

        public LoadLevelComponent(int index)
        {
            LevelIndex = index;
        }
    }
}