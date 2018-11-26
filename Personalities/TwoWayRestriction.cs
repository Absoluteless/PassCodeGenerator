using System.Collections.Generic;

namespace MisteryCore
{
    public class TwoWayRestriction : IRestriction
    {
        private readonly Personality _from;
        private readonly Personality _to;

        public TwoWayRestriction(Personality from, Personality to)
        {
            _from = from;
            _to = to;
        }

        public void Collect(IDictionary<Personality, IList<Personality>> restrictions)
        {
            restrictions.AddOrAppend(_from, _to);
            restrictions.AddOrAppend(_to, _from);
        }
    }
}
