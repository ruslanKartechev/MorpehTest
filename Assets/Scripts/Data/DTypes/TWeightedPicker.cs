using System.Collections.Generic;

namespace Data.DTypes
{
    [System.Serializable]
    public class TWeightedPicker<T> where T : class
    {
        public string Name;
        public List<TWeighted<T>> Options;
        private float _total;
        
        public void Init()
        {
            _total = 0f;
            foreach (var option in Options)
            {
                _total += option.Weight;
            }
        }
        
        public T GetOption()
        {
            var random = UnityEngine.Random.Range(0f, _total);
            foreach (var a in Options)
            {
                if (random < a.Weight)
                {
                    return a?.Value;
                }
                random -= a.Weight;
            }
            return null;
        }
    }
}