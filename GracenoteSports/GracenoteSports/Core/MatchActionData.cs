using System;

namespace GracenoteSports.Api
{
    public class MatchActionData
    {
        public int ActionId { get; set; }
        public string Competition { get; set; }
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string Period { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }
        public int HomeOrAway { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }
        public string PersonId { get; set; }
        public string Person { get; set; }
        public string Function { get; set; }
    }
}