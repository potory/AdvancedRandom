namespace AdvanceRandom.Hashers.Impl
{
    public class MurmurHash : Hasher
    {
        private const uint C1 = 0xcc9e2d51;
        private const uint C2 = 0x1b873593;

        // Overload optimized for single int input.
        public override uint GetHash(uint position, uint seed)
        {
            uint h1 = seed;
            uint k1 = position;

            // Bitmagic hash
            k1 *= C1;
            k1 = Rotl32(k1, 15);
            k1 *= C2;

            h1 ^= k1;
            h1 = Rotl32(h1, 13);
            h1 = h1 * 5 + 0xe6546b64;

            // Finalization, magic chants to wrap it all up
            h1 ^= 4U;
            h1 = Fmix(h1);

            return h1;
        }

        private static uint Rotl32(uint x, byte r)
        {
            return (x << r) | (x >> (32 - r));
        }

        private static uint Fmix(uint h)
        {
            h ^= h >> 16;
            h *= 0x85ebca6b;
            h ^= h >> 13;
            h *= 0xc2b2ae35;
            h ^= h >> 16;
            return h;
        }
    };
}