using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using GracenoteSportsApi.Core.GracenoteSports.GameEvents;
using GracenoteSportsApi.Core.GracenoteSports.Leagues;

namespace GracenoteSportsApi.WebApi.GracenoteSports
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/football-league")]
    public class GracenoteSportsController : ApiController
    {
        private readonly LeagueService _leagueService;
        private readonly GameEventService _gameEventService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leagueService"></param>
        /// <param name="gameEventService"></param>
        public GracenoteSportsController(LeagueService leagueService, GameEventService gameEventService)
        {
            _leagueService = leagueService;
            _gameEventService = gameEventService;
        }
        
        ///  <summary>
        ///  This API gives all Leagues
        ///  </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<League>))]
        public IHttpActionResult GetLeagues()
        {
            try
            {
                var leagues = _leagueService.GetAll();
                return Ok(leagues);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        ///  <summary>
        ///  This API create a League
        ///  </summary>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateLeague([FromBody]League league)
        {
            try
            {
                var updatedLeague = _leagueService.Create(league);
                return Ok(updatedLeague);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        ///  <summary>
        ///  This API gives all Game Events
        ///  </summary>
        [HttpGet]
        [Route("events")]
        [ResponseType(typeof(IEnumerable<GameEvent>))]
        public IHttpActionResult GetGameEvents()
        {
            try
            {
                var gameEvents = _gameEventService.GetAll();
                return Ok(gameEvents);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        ///  <summary>
        ///  This API creates a Game Event
        ///  </summary>
        [HttpPost]
        [Route("event")]
        public IHttpActionResult CreateGameEvent([FromBody]GameEvent gameEvent)
        {
            try
            {
                var updaGameEvent = _gameEventService.Create(gameEvent);
                return Ok(updaGameEvent);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
