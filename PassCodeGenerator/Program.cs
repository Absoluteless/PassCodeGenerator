
namespace PassCodeGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length > 1 && args[0] == "-o")
            {
                var targetFile = args[1];
                PassCodeWriter.WriteNames(targetFile);
            }
            else
            {
                var targetFile = args[0];
                PassCodeWriter.WriteCodes(targetFile);
            }
        }
    }
}
