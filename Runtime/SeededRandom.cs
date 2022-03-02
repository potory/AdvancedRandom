using AdvanceRandom.Hashers;
using AdvanceRandom.Hashers.Impl;
using Random = UnityEngine.Random;

namespace AdvanceRandom
{
    public class SeededRandom
    {
        private readonly Hasher _hasher;
        private readonly uint _seed;

        private uint _position;

        public SeededRandom() : this(new FastHasher(), (uint) Random.Range(int.MinValue, int.MaxValue))
        {
            
        }
        
        public SeededRandom(uint seed) : this(new FastHasher(), seed)
        {
            
        }

        public SeededRandom(Hasher hasher, uint seed)
        {
            _hasher = hasher;
            _seed = seed;
        }

        public int Range(int min, int max, uint position)
        {
            var hash = _hasher.GetHash(position, _seed);
            return min + (int) (hash % (max - min + 1));
        }
        
        public float Range(float min, float max, uint position)
        {
            return min + _hasher.GetHash(position, _seed) * (max - min + 1) / uint.MaxValue;
        }

        public float Next(int min, int max)
        {
            var val = Range(min, max, _position);
            _position++;
            return val;
        }
        
        public float Next(float min, float max)
        {
            var val = Range(min, max, _position);
            _position++;
            return val;
        }
    }
}