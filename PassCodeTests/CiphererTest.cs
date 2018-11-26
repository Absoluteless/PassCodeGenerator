using System;
using System.Linq;
using MisteryCore;
using NUnit.Framework;

namespace PassCodeTests
{
    [TestFixture]
    public class CiphererTeset
    {
        [Test]
        public void LongTest()
        {
            foreach (var personality in Enum.GetValues(typeof(Personality)).Cast<Personality>())
            {
                var code = Cipherer.Cipher(personality);
                var deciphered = Cipherer.Decipher(code);
                Assert.AreEqual(personality, deciphered);
            }
        }
    }
}
