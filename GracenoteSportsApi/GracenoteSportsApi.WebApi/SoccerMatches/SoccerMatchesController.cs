using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using GracenoteSportsApi.Core.SoccerMatches.LeagueTables;

namespace GracenoteSportsApi.WebApi.SoccerMatches
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api")]
    public class SoccerMatchesController : ApiController
    {
        private readonly LeagueTableReader _leagueTableReader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leagueTableReader"></param>
        public SoccerMatchesController(LeagueTableReader leagueTableReader)
        {
            _leagueTableReader = leagueTableReader;
        }
        ///  <summary>
        ///  This API gives League table based on excel file
        ///  </summary>
        [HttpGet]
        [Route("GetLeagueTables")]
        [ResponseType(typeof(IEnumerable<LeagueTableResult>))]
        public IHttpActionResult GetLeagueTables()
        {
            try
            {
                var leagueTables = _leagueTableReader.GetAll();
                return Ok(leagueTables);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
