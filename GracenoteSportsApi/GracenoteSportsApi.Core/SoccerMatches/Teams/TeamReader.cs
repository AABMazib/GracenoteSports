using System.Collections.Generic;
using GracenoteSportsApi.Core.SoccerMatches.Csv;

namespace GracenoteSportsApi.Core.SoccerMatches.Teams
{
    public class TeamReader
    {
        private readonly CsvConverter<Team> _csvConverter;

        public TeamReader(CsvConverter<Team> csvConverter)
        {
            _csvConverter = csvConverter;
        }
        public IEnumerable<Team> GetAll(string path = "Files/Teams.csv")
        {
            return _csvConverter.Convert(path, Team.FromCsv);
        }
    }
}