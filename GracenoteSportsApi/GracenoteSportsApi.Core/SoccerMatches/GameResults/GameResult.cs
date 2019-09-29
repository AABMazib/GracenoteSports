using System;

namespace GracenoteSportsApi.Core.SoccerMatches.GameResults
{
    public class GameResult
    {
        public int LeagueId { set; get; }
        public string LeagueName { set; get; }
        public int SeasonId { set; get; }
        public string Season { set; get; }
        public int GameId { set; get; }
        public DateTime GameDate { set; get; }
        public int TeamId { set; get; }
        public string TeamName { set; get; }
        public int Goals { set; get; }
        public int? Penalty { set; get; }
        public ResultType Result { set; get; }
        public static GameResult FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new GameResult
            {
                LeagueId = Convert.ToInt32(values[0]),
                LeagueName = values[1],
                SeasonId = Convert.ToInt32(values[2]),
                Season = values[3],
                GameId = Convert.ToInt32(values[4]),
                GameDate = Convert.ToDateTime(values[5]),
                TeamId = Convert.ToInt32(values[6]),
                TeamName = values[7],
                Goals = Convert.ToInt32(values[8]),
                Penalty = values[9].Equals("NULL", StringComparison.OrdinalIgnoreCase) ? (int?)null : Convert.ToInt32(values[9]),
                Result = (ResultType)Convert.ToInt32(values[10]),
            };
        }
    }
}