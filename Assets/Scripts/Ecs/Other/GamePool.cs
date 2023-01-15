using Game.View;
using Scellecs.Morpeh;

namespace Ecs.Other
{
    public class GamePool
    {
        public static World GameWorld { get; set; }
        
        public static Entity PlayerEntity { get; set; }
        public static Entity CameraEntity { get; set; }

        public static CameraView CameraView { get; set; }
    }
}