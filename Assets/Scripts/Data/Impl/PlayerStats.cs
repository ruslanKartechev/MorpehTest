using UnityEngine;

namespace Data.Impl
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SO/PlayerStats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageRadius;

        public float MoveSpeed => _moveSpeed;
        public float Damage => _damage;
        public float DamageRadius => _damageRadius;
    }
}