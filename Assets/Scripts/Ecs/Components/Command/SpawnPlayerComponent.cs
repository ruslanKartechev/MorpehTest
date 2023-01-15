using Data;
using Scellecs.Morpeh;

namespace Ecs.Components.Command
{
    public struct SpawnPlayerComponent : IComponent
    {
        public SpawnPlayerComponent(PlayerSpawnData data)
        {
            Data = data;
        }

        public PlayerSpawnData Data;
    }
}