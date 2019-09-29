namespace GracenoteSportsApi.Core.SoccerMatches.LeagueTables
{
    public class LeagueTable
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Loss { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Points { get; set; }
    }
}
