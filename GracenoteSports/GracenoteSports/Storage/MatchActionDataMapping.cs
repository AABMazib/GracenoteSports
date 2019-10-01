using TinyCsvParser.Mapping;

namespace GracenoteSports.Api
{
    public class MatchActionDataMapping : CsvMapping<MatchActionData>
    {
        public MatchActionDataMapping()
            : base()
        {
            MapProperty(0, x => x.ActionId);
            MapProperty(1, x => x.Competition);
            MapProperty(2, x => x.MatchId);
            MapProperty(3, x => x.HomeTeam);
            MapProperty(4, x => x.AwayTeam);
            MapProperty(5, x => x.HomeGoals);
            MapProperty(6, x => x.AwayGoals);
            MapProperty(7, x => x.Date);
            MapProperty(8, x => x.Action);
            MapProperty(9, x => x.Period);
            MapProperty(10, x => x.StartTime);
            MapProperty(11, x => x.EndTime);
            MapProperty(12, x => x.HomeOrAway);
            MapProperty(13, x => x.TeamId);
            MapProperty(14, x => x.Team);
            MapProperty(15, x => x.PersonId);
            MapProperty(16, x => x.Person);
            MapProperty(17, x => x.Function);
        }
    }
}