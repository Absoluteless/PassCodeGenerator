using System.IO;
using System.Linq;

namespace PassCodeGenerator
{
    public static class PassCodeWriter
    {
        public static void WriteCodes(string path)
        {
            var passcodes = PassCodeGenerator.Generate();
            File.WriteAllLines(path, passcodes);
        }

        internal static void WriteNames(string path)
        {
            var sequence = GiftSequenceGenerator.Generate();
            var lines = (from giftPair in sequence let @from = giftPair.Item1.ToString() let to = giftPair.Item2.ToString() select @from + " - " + to).ToList();
            File.WriteAllLines(path, lines);
        }
    }
}
