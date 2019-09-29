using System.Collections.Generic;
using GracenoteSportsApi.Core.SoccerMatches.Csv;

namespace GracenoteSportsApi.Core.SoccerMatches.GameResults
{
    public class GameResultReader
    {
        private readonly CsvConverter<GameResult> _csvConverter;

        public GameResultReader(CsvConverter<GameResult> csvConverter)
        {
            _csvConverter = csvConverter;
        }
        public IEnumerable<GameResult> GetAll(string path = "Files/Game_Results.csv")
        {
            return _csvConverter.Convert(path, GameResult.FromCsv);
        }
    }
}