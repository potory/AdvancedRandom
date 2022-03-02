namespace AdvanceRandom.Hashers.Impl
{
    public class FastHasher : Hasher
    {
        public override uint GetHash(uint position, uint seed)
        {
            const uint bitNoise1 = 0xb5297a4d;
            const uint bitNoise2 = 0x68e31da4;
            const uint bitNoise3 = 0x1b56c4e9;

            var mangled = position;

            mangled *= bitNoise1;
            mangled += seed;
            mangled ^= (mangled >> 8);
            mangled += bitNoise2;
            mangled ^= (mangled << 8);
            mangled *= bitNoise3;
            mangled ^= (mangled >> 8);

            return mangled;
        }
    }
}