using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEditor;

namespace Game.Level.Impl
{
    public class LevelView : MonoBehaviour
    { 
         public List<EnemySpawnData> spawnPoints;
         public Transform cameraPosition;
         public PlayerSpawnData PlayerSpawnData;
         
         public void GenerateGrid()
         {
         }

         public void Clear()
         {
         }
    }
    
    
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(LevelView))]
    public class LevelViewEditor : Editor
    {
        private LevelView me;

        private void OnEnable()
        {
            me = target as LevelView;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Spawn"))
            {
                me.GenerateGrid();
            }
            if (GUILayout.Button("Clear"))
            {
                me.Clear();
            }
        }
    }
    #endif
}
