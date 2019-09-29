using System.Collections.Generic;
using System.Linq;
using GracenoteSportsApi.Core.SoccerMatches.GameResults;

namespace GracenoteSportsApi.Core.SoccerMatches.LeagueTables
{
    public class LeagueTableReader
    {
        private readonly GameResultReader _gameResultReader;

        public LeagueTableReader(GameResultReader gameResultReader)
        {
            _gameResultReader = gameResultReader;
        }

        public IEnumerable<LeagueTableResult> GetAll()
        {
            IEnumerable<LeagueTable> GetLeagueTable(IEnumerable<GameResult> results)
            {
                return results.GroupBy(r => r.TeamId).Select(g => new LeagueTable
                {
                    TeamId = g.Key,
                    TeamName = g.First().TeamName,
                    Loss = g.Count(x => x.Result == ResultType.Loss),
                    Win = g.Count(x => x.Result == ResultType.Win),
                    Draw = g.Count(x => x.Result == ResultType.Draw),
                    Points = g.Select(x => x.Result == ResultType.Loss ? 0 : (x.Result == ResultType.Draw ? 1 : 3))
                        .Sum()
                }).OrderByDescending(l => l.Points).ToList();
            }

            var result = _gameResultReader.GetAll();
            return result.GroupBy(r => r.LeagueId)
                .Select(g => new LeagueTableResult
                {
                    League = new League {Id = g.Key, Name = g.First().LeagueName},
                    LeagueTables = GetLeagueTable(g)
                });
        }
    }
}
