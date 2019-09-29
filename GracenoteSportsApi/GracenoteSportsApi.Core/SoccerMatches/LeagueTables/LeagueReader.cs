using System.Collections.Generic;
using System.Linq;
using GracenoteSportsApi.Core.SoccerMatches.GameResults;

namespace GracenoteSportsApi.Core.SoccerMatches.LeagueTables
{
    public class LeagueReader
    {
        private readonly GameResultReader _gameResultReader;

        public LeagueReader(GameResultReader gameResultReader)
        {
            _gameResultReader = gameResultReader;
        }
        public IEnumerable<League> GetAll()
        {
            var results = _gameResultReader.GetAll();
            return results.GroupBy(r => r.LeagueId).Select(g => new League
            {
                Id = g.Key,
                Name = g.First().LeagueName
            });
        }
    }
}