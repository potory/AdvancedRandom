namespace AdvanceRandom.Hashers
{
    public abstract class Hasher
    {
        public abstract uint GetHash(uint position, uint seed);
    }
}