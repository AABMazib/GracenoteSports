using System.Collections.Generic;
using GracenoteSportsApi.Core.GracenoteSports.Leagues;
using GracenoteSportsApi.Core.Interfaces;

namespace GracenoteSportsApi.Infrastructure.Data
{
    public class InMemoryLeagueRepository : ILeagueRepository
    {
        private static readonly List<League> Leagues = new List<League> {new League {Id = 1, Name = "Premier League"}};

        public League Create(League league)
        {
            Leagues.Add(league);
            return league;
        }

        public IEnumerable<League> GetAll()
        {
            return Leagues;
        }
    }
}