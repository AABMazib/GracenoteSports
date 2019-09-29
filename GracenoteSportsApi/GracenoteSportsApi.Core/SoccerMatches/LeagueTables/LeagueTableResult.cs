using System.Collections.Generic;

namespace GracenoteSportsApi.Core.SoccerMatches.LeagueTables
{
    public class LeagueTableResult
    {
        public League League { get; set; }
        public IEnumerable<LeagueTable> LeagueTables { get; set; }
    }
}