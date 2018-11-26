using System.Collections.Generic;

namespace MisteryCore
{
    public class OneWayRestriction : IRestriction
    {
        private readonly Personality _from;
        private readonly Personality _to;

        public OneWayRestriction(Personality from, Personality to)
        {
            _from = from;
            _to = to;
        }

        public void Collect(IDictionary<Personality, IList<Personality>> restrictions)
        {
            restrictions.AddOrAppend(_from, _to);
        }
    }
}
