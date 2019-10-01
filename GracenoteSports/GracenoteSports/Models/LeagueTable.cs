using System.Collections.Generic;

namespace GracenoteSports.Api
{
    public class LeagueTable
    {
        public string LeagueId { get; set; }
        public IEnumerable<Ranking> Rankings { get; set; }
    }
}