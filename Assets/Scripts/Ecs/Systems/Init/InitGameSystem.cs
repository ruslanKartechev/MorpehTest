using Data;
using Data.Level;
using Ecs.Components;
using Ecs.Components.Command;
using Ecs.Other;
using Scellecs.Morpeh;
using Zenject;

namespace Ecs.Systems
{
    public class InitGameSystem : IInitializer
    {
        [Inject] private ILevelRepository _levelRepository;
        
        public void OnAwake()
        {
            var game = GamePool.PlayerEntity;
            
            ref var level = ref game.GetComponent<CurrentLevelComponent>();
            level.Value = _levelRepository.CurrentLevelIndex;
            ref var state = ref game.GetComponent<GameStateComponent>();
            state.State = EGameState.LevelPlay;
            
            var loadLevel = new LoadLevelComponent(level.Value);
            World.CreateEntity().SetComponent(loadLevel);
        }

        public World World { get; set; }
        
        public void Dispose()
        {
        }
    }
}