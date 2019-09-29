using System;

namespace GracenoteSportsApi.Core.GracenoteSports.GameEvents
{
    public class GameEvent
    {
        public int Id { get; set; }
        public string LeagueName { set; get; }
        public string Season { set; get; }
        public DateTime GameDate { set; get; }
        public string Team1Name { set; get; }
        public string Team2Name { set; get; }
        public int Team1Goals { set; get; }
        public int Team2Goals { set; get; }
    }
}