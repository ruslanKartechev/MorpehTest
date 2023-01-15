using UnityEngine;

namespace Data.Impl
{
    [CreateAssetMenu(fileName = nameof(GlobalSettings), menuName = "SO/" + nameof(GlobalSettings))]
    public class GlobalSettings : ScriptableObject, 
        IGlobalSettings
    {
        [SerializeField] private float _spawnRad;
        [SerializeField] private int _maxEnemyDamageCount;

        public int MaxDamageCount => _maxEnemyDamageCount;
        public float SpawnRad => _spawnRad;
    }
}