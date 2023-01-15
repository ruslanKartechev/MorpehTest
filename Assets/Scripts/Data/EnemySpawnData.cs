using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class EnemySpawnData
    {
        public EEnemyType EnemyType;
        public int Health;
        public Transform SpawnPoint;
    }
}