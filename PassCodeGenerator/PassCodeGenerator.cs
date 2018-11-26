using System.Collections.Generic;
using System.Linq;
using MisteryCore;

namespace PassCodeGenerator
{
    internal static class PassCodeGenerator
    {
        public static IEnumerable<string> Generate()
        {
            var sequence = GiftSequenceGenerator.Generate();
            return (from giftPair in sequence let @from = giftPair.Item1.ToString() let to = Cipherer.Cipher(giftPair.Item2) select @from + to).ToList();
        }
    }
}
