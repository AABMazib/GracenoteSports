using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace GracenoteSports.Api
{
    public class MatchActionDataRepository: IMatchActionDataRepository
    {
        private readonly IHostingEnvironment _environment;
        public MatchActionDataRepository(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public Task<IEnumerable<MatchActionData>> GetMatchActionDataAsync()
        {
            string actionDataFile = $"{_environment.ContentRootPath}/storage/files/MatchActions_PremierLeague20182019_20190927.csv";

            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvMapper = new MatchActionDataMapping();
            var csvParser = new CsvParser<MatchActionData>(csvParserOptions, csvMapper);
            var actionData = csvParser
                .ReadFromFile(actionDataFile, Encoding.UTF8)
                .Select(ad => {

                    return ad.Result;
                })
                .ToList();
            return Task.FromResult(actionData.AsEnumerable());
        }
    }
}