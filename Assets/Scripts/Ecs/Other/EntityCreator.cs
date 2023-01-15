using Ecs.Components;
using Ecs.Components.View;
using Game.View;
using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Other
{
    public class EntityCreator
    {
        
        public static Entity CreatePlayerEntity(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<GameStateComponent>();
            entity.AddComponent<CurrentLevelComponent>();
            entity.SetComponent(new KillCountComponent(0));
            return entity;
        }

        public static Entity CreatePlayerCharacter(World world, 
            PlayerView view,
            Vector3 position,
            Quaternion rotation,
            float moveSpeed,
            float damageRad,
            float damage)
        {
            var playerEntity = world.CreateEntity();
            playerEntity.AddComponent<PlayerComponent>();
            playerEntity.SetComponent(new PositionComponent(position));
            playerEntity.SetComponent(new RotationComponent(rotation));
            playerEntity.SetComponent(new SimpleViewComponent(view.transform));
            playerEntity.SetComponent(new MoveSpeedComponent(moveSpeed));
            playerEntity.SetComponent(new DamageRangeComponent(damageRad));
            playerEntity.SetComponent(new DamageComponent(damage));
            playerEntity.SetComponent(new DamageElapsedComponent());
            return playerEntity;
        }
        
        

    }
}