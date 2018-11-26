using System;
using System.Collections.Generic;
using System.Linq;
using MisteryCore;

namespace PassCodeGenerator
{
    public static class GiftSequenceGenerator
    {
        public static IEnumerable<Tuple<Personality, Personality>> Generate()
        {
            IEnumerable<Tuple<Personality, Personality>> results = null;
            bool success;
            do
            {
                try
                {
                    results = TryGenerate();
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                }
            } while (!success);

            return results.OrderBy(p => p.Item1.ToString());
        }

        private static IEnumerable<Tuple<Personality, Personality>> TryGenerate()
        {
            var results = new List<Tuple<Personality, Personality>>();

            var totalPersonalities = Enum.GetValues(typeof(Personality)).Cast<Personality>();
            var toPersons = totalPersonalities.ToList();

            var init = toPersons[0];
            toPersons.RemoveAt(0);

            var current = init;
            while (toPersons.Count > 0)
            {
                var nextNumber = RandomHolder.Random.Next(toPersons.Count);
                var next = toPersons[nextNumber];

                if (Restrictions.AreRestricted(current, next))
                    throw new Exception();

                toPersons.RemoveAt(nextNumber);
                results.Add(new Tuple<Personality, Personality>(current, next));
                current = next;
            }

            if (Restrictions.AreRestricted(current, init))
                throw new Exception();

            results.Add(new Tuple<Personality, Personality>(current, init));

            return results;
        }
    }
}