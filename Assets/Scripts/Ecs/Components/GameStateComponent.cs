using Data;
using Scellecs.Morpeh;

namespace Ecs.Components
{
    public struct GameStateComponent : IComponent
    {
        public EGameState State;

        public GameStateComponent(EGameState state)
        {
            State = state;
        }
    }
}