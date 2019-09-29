using System.Collections.Generic;
using System.Linq;
using GracenoteSportsApi.Core.Interfaces;

namespace GracenoteSportsApi.Core.GracenoteSports.Leagues
{
    public class LeagueService
    {
        private readonly ILeagueRepository _leagueRepository;

        public LeagueService(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }
        public League Create(League league)
        {
            var leages = _leagueRepository.GetAll().ToList();
            var duplicate = leages.FirstOrDefault(l => l.Name == league.Name);
            if (duplicate != null)
            {
                return duplicate;
            }
            var id = leages.Count;
            league.Id = id + 1;
            _leagueRepository.Create(league);
            return league;
        }

        public IEnumerable<League> GetAll()
        {
            return _leagueRepository.GetAll();
        }
    }
}