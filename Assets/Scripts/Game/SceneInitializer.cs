using Ecs.Other;
using Game.View;
using UnityEngine;

namespace Game
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private CameraView _cameraView;
        
        public void Run()
        {
            GamePool.CameraView = _cameraView;
        }
    }
   
}
