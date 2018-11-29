using System;
using System.Linq;

namespace MisteryCore
{
    public static class Cipherer
    {
        private const int MagicNumber1 = 59;
        private const int MagicNumber2 = 61;
        private const int MagicNumber3 = 3;
        private const int MagicNumber4 = 7;

        public static string Cipher(Personality person)
        {
            return Code((int) person);
        }

        private static string Code(int toCipher)
        {
            var numbers = new int[4];
            numbers[0] = RandomHolder.Random.Next(99);
            numbers[1] = RandomHolder.Random.Next(99);
            numbers[2] = MagicNumber1 - numbers[0] % MagicNumber1 + toCipher * MagicNumber3;
            numbers[3] = MagicNumber2 - numbers[1] % MagicNumber2 + toCipher + MagicNumber4;
            return numbers[0].ToString("00") + numbers[1].ToString("00") + numbers[2].ToString("00") + numbers[3].ToString("00");
        }

        public static Personality Decipher(string code)
        {
            return (Personality) Decode(code);
        }

        private static int Decode(string code)
        {
            var numbers = new int[4];
            numbers[0] = int.Parse(code.Substring(0, 2));
            numbers[1] = int.Parse(code.Substring(2, 2));
            numbers[2] = int.Parse(code.Substring(4, 2));
            numbers[3] = int.Parse(code.Substring(6, 2));

            var checkSum1 = (numbers[0] + numbers[2]) % MagicNumber1 / MagicNumber3;
            var checkSum2 = (numbers[1] + numbers[3]) % MagicNumber2 - MagicNumber4;
            var max = (int) Enum.GetValues(typeof(Personality)).Cast<Personality>().Max();

            if (checkSum1 != checkSum2 || checkSum2 > max)
                throw new Exception("Wrong passcode");
            return checkSum1;
        }
    }
}
