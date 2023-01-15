using Ecs.Components;
using Ecs.Other;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Ecs.Systems
{
    public class CaptureInputSystem : UpdateSystem
    {
        
        public override void OnAwake()
        {
            
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = GamePool.PlayerEntity;
            var x = 0;
            var y = 0;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                y = 1;
            } 
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                y = -1;
            }
            
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                x = 1;
            } 
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                x = -1;
            }
            var inputVector = new Vector2(x, y);
            player.SetComponent(new InputComponent(inputVector));
        }
    }
}