using Data.Level.Impl;
using Helpers;
using Services.Instantiate;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Game.Level.Impl
{
    public class LevelLoader : MonoBehaviour, ILevelLoader
    {
        [SerializeField] private LevelRepository levelRepository;
        [SerializeField] private Transform _parent;
        
        [Inject] private IInstantiateService _instantiateService;
        public bool EditorMode { get; set; }

        
        // ReSharper disable Unity.PerformanceAnalysis
        public LevelView LoadLevel(int levelIndex)
        {
            if (_parent == null)
                _parent = transform;            
            
            var prefab = levelRepository.GetPrefab(levelIndex);
#if UNITY_EDITOR
            if (Application.isPlaying == false)
            {
                var editorInstance = PrefabUtility.InstantiatePrefab(prefab, _parent) as GameObject;
                var levelInstance = editorInstance.GetComponent<LevelView>();
                if (levelInstance == null)
                    Debug.LogError($"No ILevelInstance fount on level prefab");
                return levelInstance;
            }
#endif
            var instance = _instantiateService.Spawn<LevelView>(prefab.gameObject, _parent);
            return instance;
        }

        public void ClearLevel()
        {
            for (int i = 0; i < _parent.childCount; i++)
            {
                var go = _parent.GetChild(i).gameObject;
                if (Application.isPlaying)
                {
                    go.SetActive(false);
                    go.transform.SetParent(null);
                    // Destroy(go);
                }
                else
                    DestroyImmediate(go);
            }
        }

    }
}