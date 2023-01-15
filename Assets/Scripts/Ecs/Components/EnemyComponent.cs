using Data;
using Scellecs.Morpeh;

namespace Ecs.Components
{
    public struct EnemyComponent : IComponent
    {
        public EnemyComponent(EEnemyType value)
        {
            Value = value;
        }

        public EEnemyType Value;
        
        
    }
}