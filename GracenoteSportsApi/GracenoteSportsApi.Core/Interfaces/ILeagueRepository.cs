using System.Collections.Generic;
using GracenoteSportsApi.Core.GracenoteSports.Leagues;

namespace GracenoteSportsApi.Core.Interfaces
{
    public interface ILeagueRepository
    {
        League Create(League league);
        IEnumerable<League> GetAll();
    }
}