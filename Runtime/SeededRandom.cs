using System;
using AdvanceRandom.Hashers.Impl;
using Random = UnityEngine.Random;

namespace AdvanceRandom
{
    public class SeededRandom
    {
        private readonly Func<uint, uint, uint> _hashFunc;
        private readonly uint _seed;

        private uint _position;

        public SeededRandom(Func<uint, uint, uint> hashFunc = null, uint? seed = null)
        {
            _hashFunc = hashFunc ?? FastHasher.GetHash;
            _seed = seed ?? (uint) Random.Range(int.MinValue, int.MaxValue);
        }

        public int Range(int minInclusive, int maxExclusive, uint position)
        {
            var hash = _hashFunc(position, _seed);
            return minInclusive + (int) (hash % (maxExclusive - minInclusive));
        }
        
        public float Range(float minInclusive, float maxExclusive, uint position)
        {
            return minInclusive + _hashFunc(position, _seed) * (maxExclusive - minInclusive) / uint.MaxValue;
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