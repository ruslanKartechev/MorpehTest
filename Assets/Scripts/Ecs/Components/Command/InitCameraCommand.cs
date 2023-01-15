using Game.View;
using Scellecs.Morpeh;

namespace Ecs.Components.Command
{
    public struct InitCameraCommand : IComponent
    {
        public InitCameraCommand(CameraView camView)
        {
            CamView = camView;
        }

        public CameraView CamView;
        
    }
}