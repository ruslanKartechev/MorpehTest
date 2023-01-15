using Ecs.Components;
using Ecs.Other;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;

namespace Ecs.Systems
{
    public class MovePlayerSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerComponent>().With<PositionComponent>().With<RotationComponent>().With<MoveSpeedComponent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var posComp = ref entity.GetComponent<PositionComponent>();
                var moveSpeed = entity.GetComponent<MoveSpeedComponent>().Property.Value;
                var pos = posComp.Value;

                var input = GamePool.PlayerEntity.GetComponent<InputComponent>().MoveInput;
                
                pos.x += moveSpeed * deltaTime * input.x;
                pos.z += moveSpeed * deltaTime * input.y;
                
                posComp.Value = pos;
            }   
            
        }
    }
}