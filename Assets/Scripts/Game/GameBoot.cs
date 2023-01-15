using System;
using Ecs.Components;
using Ecs.Other;
using GameUI;
using Helpers;
using Scellecs.Morpeh;
using UnityEngine;
using Zenject;

namespace Game
{
    [DefaultExecutionOrder(-1)]
    public class GameBoot : MonoBehaviour
    {
        [SerializeField] private SceneContext _sceneContext;
        [SerializeField] private SceneInitializer _sceneInitializer;

        [Inject] private DiContainer _container;
        
        private void Awake()
        {
            InitLogs();
            _sceneContext.Run();
            _sceneInitializer.Run();
            EcsInit.Init(_container);   
        }

        private void Start()
        {
        }

        private void InitLogs()
        {
            Dbg.EnableDebugs = true;
        }

        
    }
}