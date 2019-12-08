using System.Collections.Generic;

namespace MisteryCore
{
    internal static class RestrictionFiller
    {
        public static IEnumerable<IRestriction> GetRestrictions()
        {
            return new List<IRestriction>
            {
                new TwoWayRestriction(Personality.LeshaKalinin, Personality.TanyaAnisimova),
                new TwoWayRestriction(Personality.SashaMoskvicheva, Personality.StefanMorozov),
                new TwoWayRestriction(Personality.RuslanShaimardanov, Personality.MashaGlinskaya),
                new OneWayRestriction(Personality.MarkBondarenko, Personality.SashaMoskvicheva),
                new OneWayRestriction(Personality.MarkBondarenko, Personality.StefanMorozov),
                new OneWayRestriction(Personality.MarkBondarenko, Personality.NastyaRozkina),
                new OneWayRestriction(Personality.TanyaAnisimova, Personality.RuslanShaimardanov),
                new OneWayRestriction(Personality.TanyaAnisimova, Personality.MarkBondarenko),
                new OneWayRestriction(Personality.RuslanShaimardanov, Personality.MarkBondarenko),
                new OneWayRestriction(Personality.LenaMelikhova, Personality.NastyaRozkina),
                new OneWayRestriction(Personality.NastyaRozkina, Personality.LenaMelikhova),
                new OneWayRestriction(Personality.NastyaRozkina, Personality.RuslanShaimardanov),
                new OneWayRestriction(Personality.StefanMorozov, Personality.TanyaAnisimova),
                new OneWayRestriction(Personality.SashaMoskvicheva, Personality.TanyaAnisimova),
            };
        }
    }
}
