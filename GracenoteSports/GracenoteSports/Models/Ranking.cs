namespace GracenoteSports.Api
{
    public class Ranking
    {
        public int Rank { get; set; }
        public string TeamId { get; set; }
        public int MatchPlayed { get; set; }
        public int MatchWon { get; set; }
        public int MatchLost { get; set; }
        public int MatchDrawn { get; set; }
        public int Points { get; set; }
    }
}