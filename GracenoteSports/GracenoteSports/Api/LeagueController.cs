using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GracenoteSports.Api
{
    //[Authorize(Policy = Policies.Authenticated)]
    [Route("api/league")]
    public class LeagueController : Controller
    {
        private readonly IMatchActionDataRepository _matchActionDataRepository;

        public LeagueController(IMatchActionDataRepository matchActionDataRepository)
        {
            _matchActionDataRepository = matchActionDataRepository;
        }

        /// <summary>
        /// Retrieve the league table of a given league
        /// </summary>
        /// <param name="id">League identifier, e.g. 06A890F8-6F1E-4C0D-A4A6-5B66C3E76C37</param>
        /// <returns>If valid, the league table given id; otherwise null</returns>
        /// <remarks>
        /// - System Administrator can access content for all customers
        /// - Other users can only access content for its 'own' customer
        /// </remarks>
        [HttpGet]
        //[Authorize(Policy = Policies.RequireRead)]
        //[SwaggerOperation(Produces = new[] { "application/json" })]
        //[SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetContentResponseExample))]
        //[ProducesResponseType(typeof(ApiModel.Content), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        [Route("{id}/table")]
        public async Task<IActionResult> GetLeagueTableByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is missing.");
            }

            var matchActions = await _matchActionDataRepository.GetMatchActionDataAsync();

            var rankings = matchActions
                .Where(ma => id == ma.Competition)
                .GroupBy(ma => ma.MatchId)
                .Select(group => group.First())
                .SelectMany(ma =>
                {
                    var homeWon = ma.HomeGoals > ma.AwayGoals;
                    var homeLost = ma.HomeGoals < ma.AwayGoals;
                    if (homeWon)
                    {
                        return new[] {
                            new { TeamId = ma.HomeTeam, Won = true, Point = 3, Goal = ma.HomeGoals },
                            new { TeamId = ma.AwayTeam, Won = false, Point = 0, Goal = ma.AwayGoals }
                        };
                    }
                    else if (homeLost)
                    {
                        return new[] {
                            new { TeamId = ma.HomeTeam, Won = false, Point = 0, Goal = ma.HomeGoals },
                            new { TeamId = ma.AwayTeam, Won = true, Point = 3, Goal = ma.AwayGoals }
                        };
                    }
                    else // drawn
                    {
                        return new[] {
                            new { TeamId = ma.HomeTeam, Won = false, Point = 1, Goal = ma.HomeGoals },
                            new { TeamId = ma.AwayTeam, Won = false, Point = 1, Goal = ma.AwayGoals }
                        };
                    }

                })
                .GroupBy(result => result.TeamId)
                .Select(grouped =>
                {
                    var teamId = grouped.Key;
                    var data = grouped.ToList();

                    var matchPlayed = data.Count;
                    var matchWon = data.Count(d => d.Won);
                    var matchLost = data.Count(d => !d.Won);
                    var ranking = new Ranking
                    {
                        TeamId = teamId,
                        MatchPlayed = matchPlayed,
                        MatchWon = matchWon,
                        MatchLost = matchLost,
                        MatchDrawn = matchPlayed - matchWon - matchLost,
                        Points = data.Sum(d => d.Point)
                    };

                    return ranking;
                })
                .OrderBy(ranking => ranking.Points)
                .Select((ranking, index) =>
                {
                    ranking.Rank = index + 1;
                    return ranking;
                }).ToList();

            var leagueTable = new LeagueTable
            {
                LeagueId = id,
                Rankings = rankings
            };

            return Ok(leagueTable);
        }

        [HttpGet]
        //[Authorize(Policy = Policies.RequireRead)]
        //[SwaggerOperation(Produces = new[] { "application/json" })]
        //[SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetContentResponseExample))]
        //[ProducesResponseType(typeof(ApiModel.Content), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        [Route("{id}/matches/{matchId:int}/lineup")]
        public async Task<IActionResult> GetLineupAsync(string id, int? matchId)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is missing.");
            }

            if (null == matchId)
            {
                throw new ArgumentException("matchId is missing.");
            }

            var matchActions = await _matchActionDataRepository.GetMatchActionDataAsync();

            var teams = matchActions
                .Where(
                ma => "Line-up" == ma.Action && "Start" == ma.Period && ma.TeamId > 0
                    && "Coach" != ma.Function && id == ma.Competition && matchId == ma.MatchId
                )
                .GroupBy(ma => ma.TeamId)
                .Select(grouped =>
                {
                    var data = grouped.ToList();
                    var match = data.First();
                    var players = data.Select(ma => new
                    {
                        Name = ma.Person
                    }).ToArray();
                    var goals = match.Team == match.HomeTeam ? match.HomeGoals : match.AwayGoals;

                    return new
                    {
                        Home = match.Team == match.HomeTeam,
                        Name = match.Team,
                        Goals = goals,
                        Players = players
                    };
                }).ToList();

            var home = teams.First(team => team.Home);
            var away = teams.First(team => team != home);

            return Ok(new
            {
                Home = new
                {
                    home.Name,
                    home.Goals,
                    home.Players
                },
                Away = new
                {
                    away.Name,
                    away.Goals,
                    away.Players
                }
            });
        }
    }
}