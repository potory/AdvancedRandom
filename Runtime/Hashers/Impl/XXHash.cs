namespace AdvanceRandom.Hashers.Impl
{
    public static class XxHash
    {
        private const uint Prime1 = 2246822519U;
        private const uint Prime2 = 3266489917U;
        private const uint Prime3 = 668265263U;
        private const uint Prime4 = 374761393U;

        public static uint GetHash(uint position, uint seed)
        {
            var h32 = seed + Prime4;
            h32 += 4U;
            h32 += (uint) position * Prime2;
            h32 = RotateLeft(h32, 17) * Prime3;
            h32 ^= h32 >> 15;
            h32 *= Prime1;
            h32 ^= h32 >> 13;
            h32 *= Prime2;
            h32 ^= h32 >> 16;
            return h32;
        }

        private static uint RotateLeft(uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }
    }
}