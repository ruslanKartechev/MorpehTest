using Data.Level.Impl;
using UnityEngine;
using Zenject;

namespace Game.Level.Impl
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        public bool IsEditor = true;
        public int Editor_Index = 0;
        public int Editor_Total = 0;

        [SerializeField] private LevelRepository levelRepository;

        [Inject] private ILevelLoader _levelLoader;
        private LevelView _current;

        public int TotalLevelsCompleted
        {
            get => IsEditor ? Editor_Total : levelRepository.TotalLevelsPassed;
            set
            {
                var val = levelRepository.TotalLevelsPassed++;
                if (IsEditor)
                    Editor_Total = value;
                // EntityPool.Player.ChangePassedLevelsCount(val);
            }
        }

        private void OnValidate()
        {
            _levelLoader = GetComponent<ILevelLoader>();
        }

        public void LoadCurrent()
        {
            _levelLoader.EditorMode = IsEditor;
            ClearLevel();
            if (IsEditor)
            {
                _current = _levelLoader.LoadLevel(Editor_Index);
            }
            else
            {
                var index = levelRepository.CurrentLevelIndex;
                _current = _levelLoader.LoadLevel(index);
            }
            if (Application.isPlaying)
            {
                if (_current == null)
                    return;
                // CommandsPool.ExecuteCommand(new InitLevelCommand(_current));
            }
        }

        private void ClearLevel()
        {
            if (Application.isPlaying)
            {
                // CommandsPool.ExecuteCommand(new ClearLevelCommand());
            }
            _levelLoader.ClearLevel();
            _current = null;
        }

        public void NextLevel()
        {
            _levelLoader.EditorMode = IsEditor;
            ClearLevel();
            if (IsEditor)
            {
                Editor_Index = levelRepository.CorrectIndex(Editor_Index + 1);
                _current = _levelLoader.LoadLevel(Editor_Index);
                Editor_Total++;
            }
            else
            {
                var index = levelRepository.NextLevel();
                _current = _levelLoader.LoadLevel(index);
            }
            if (Application.isPlaying)
            {
                if (_current == null)
                    return;
                // CommandsPool.ExecuteCommand(new InitLevelCommand(_current));
            }
        }

        public void PreviousLevel()
        {
            _levelLoader.EditorMode = IsEditor;
            if (IsEditor)
            {
                Editor_Index = levelRepository.CorrectIndex(Editor_Index - 1);
                _levelLoader.ClearLevel();
                _levelLoader.LoadLevel(Editor_Index);
                Editor_Total--;
                if (Editor_Total < 0)
                    Editor_Total = 0;
                return;
            }
            var index = levelRepository.PrevLevel();
            _current = _levelLoader.LoadLevel(index);
        }

    }
}