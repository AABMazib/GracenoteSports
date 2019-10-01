using System.Collections.Generic;
using System.Threading.Tasks;

namespace GracenoteSports.Api
{
    public interface IMatchActionDataRepository
    {
        Task<IEnumerable<MatchActionData>> GetMatchActionDataAsync();
    }
}