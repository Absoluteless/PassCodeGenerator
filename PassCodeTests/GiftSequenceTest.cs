using System;
using System.Linq;
using MisteryCore;
using NUnit.Framework;
using PassCodeGenerator;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PassCodeTests
{
    [TestFixture]
    public class GiftSequenceTest
    {
        [Test]
        public void TestSequense()
        {
            var sequence = GiftSequenceGenerator.Generate();
            var fromList = Enum.GetValues(typeof(Personality)).Cast<Personality>().ToList();
            var toList = Enum.GetValues(typeof(Personality)).Cast<Personality>().ToList();
            foreach (var pair in sequence)
            {
                Assert.AreNotEqual(pair.Item1, pair.Item2);
                Assert.IsFalse(Restrictions.AreRestricted(pair.Item1, pair.Item2));
                fromList.Remove(pair.Item1);
                toList.Remove(pair.Item2);
            }
            Assert.AreEqual(0, fromList.Count);
            Assert.AreEqual(0, toList.Count);
        }
    }
}
