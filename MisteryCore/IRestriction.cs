using System.Collections.Generic;

namespace MisteryCore
{
    internal interface IRestriction
    {
        void Collect(IDictionary<Personality, IList<Personality>> restrictions);
    }
}
