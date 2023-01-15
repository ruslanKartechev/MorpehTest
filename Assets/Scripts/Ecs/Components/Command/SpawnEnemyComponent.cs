using Data;
using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Components.Command
{
    public struct SpawnEnemyComponent : IComponent
    {
        public SpawnEnemyComponent(Vector3 position, Quaternion rotation, EEnemyType enemyType, float health)
        {
            Position = position;
            Rotation = rotation;
            EnemyType = enemyType;
            Health = health;
        }

        public Vector3 Position;
        public Quaternion Rotation;
        public EEnemyType EnemyType;
        public float Health;
        
    }
}