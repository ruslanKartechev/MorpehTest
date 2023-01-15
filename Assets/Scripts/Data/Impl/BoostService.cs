using Data.DTypes;
using UnityEngine;

namespace Data.Impl
{
    [CreateAssetMenu(fileName = "BoostService", menuName = "SO/BoostService")]
    public class BoostService :  TWeightedPickerSO<Boost>, IBoostService
    {
        private void OnEnable()
        {
            Init();
        }

        public Boost GetRandomBoost()
        {
           return GetOption();
        }
     
    }
}