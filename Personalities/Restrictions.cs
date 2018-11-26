using System.Collections.Generic;

namespace MisteryCore
{
    public static class Restrictions
    {
        public static IDictionary<Personality, IList<Personality>> RestrictionDictionary { get; }

        static Restrictions()
        {
            RestrictionDictionary = new Dictionary<Personality, IList<Personality>>();
            var restrictions = RestrictionFiller.GetRestrictions();
            foreach (var restriction in restrictions)
            {
                restriction.Collect(RestrictionDictionary);
            }
        }

        public static bool AreRestricted(Personality a, Personality b)
        {
            return RestrictionDictionary.TryGetValue(a, out var restricted) && restricted.Contains(b);
        }
    }
}
