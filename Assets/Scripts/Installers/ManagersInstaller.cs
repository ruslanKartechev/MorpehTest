﻿using Game;
using Game.Sound.Impl;
using GameUI.Impl;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ManagersInstaller : MonoInstaller
    {
        [SerializeField] private SoundManager _soundManager;
        [SerializeField] private AudioSourceProvider _audioSourceProvider;
        [SerializeField] private PlayerHudUI _playerHud;

        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SoundManager>().FromInstance(_soundManager).AsSingle();
            Container.BindInterfacesAndSelfTo<AudioSourceProvider>().FromInstance(_audioSourceProvider).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerHudUI>().FromInstance(_playerHud).AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        }
        
    }
}