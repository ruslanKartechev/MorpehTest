using Scellecs.Morpeh;
using UnityEngine;

namespace Ecs.Components
{
    public struct InputComponent : IComponent
    {
        public Vector2 MoveInput;

        public InputComponent(Vector2 moveInput)
        {
            MoveInput = moveInput;
        }
    }
}