using System;

namespace MisteryCore
{
    public static class RandomHolder
    {
        public static Random Random { get; }

        static RandomHolder()
        {
            Random = new Random();        
        }
    }
}
