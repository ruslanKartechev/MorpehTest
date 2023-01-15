using Data.Impl;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public struct PlayerSpawnData
    {
        public Transform Point;
        public PlayerStats Stats;
    }
}