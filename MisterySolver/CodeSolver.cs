using System;
using MisteryCore;

namespace MisterySolver
{
    internal static class CodeSolver
    {
        internal static bool TrySolve(string code, out Personality from, out Personality to)
        {
            from = 0;
            to = 0;

            return SolveFrom(code, out from) && SolveTo(code, out to);
        }

        private static bool SolveFrom(string code, out Personality from)
        {
            from = 0;

            if (code.Length < 9)
                return false;

            var fromName = code.Substring(0, code.Length - 8);

            if (fromName.Length < 3)
                return false;

            if (!Enum.TryParse(fromName, out from))
                return false;

            return true;
        }

        private static bool SolveTo(string code, out Personality to)
        {
            to = 0;

            try
            {
                var toPersonCode = code.Substring(code.Length - 8, 8);
                to = Cipherer.Decipher(toPersonCode);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
