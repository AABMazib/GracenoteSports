using System.Reflection;
using Autofac;
using Autofac.Integration.Mef;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GracenoteSportsApi.Core.GracenoteSports.GameEvents;
using GracenoteSportsApi.Core.GracenoteSports.Leagues;
using GracenoteSportsApi.Core.Interfaces;
using GracenoteSportsApi.Core.SoccerMatches.Csv;
using GracenoteSportsApi.Core.SoccerMatches.GameResults;
using GracenoteSportsApi.Core.SoccerMatches.LeagueTables;
using GracenoteSportsApi.Core.SoccerMatches.Teams;
using GracenoteSportsApi.Infrastructure.Data;

namespace GracenoteSportsApi.WebApi
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterMetadataRegistrationSources();
            

            builder.RegisterType<LeagueReader>().InstancePerRequest();
            builder.RegisterType<CsvConverter<Team>>().InstancePerRequest();
            builder.RegisterType<CsvConverter<GameResult>>().InstancePerRequest();
            builder.RegisterType<TeamReader>().InstancePerRequest();
            builder.RegisterType<LeagueTableReader>().InstancePerRequest();
            builder.RegisterType<GameResultReader>().InstancePerRequest();
            builder.RegisterType<InMemoryLeagueRepository>().As<ILeagueRepository>().InstancePerRequest();
            builder.RegisterType<InMemoryGameEventReposigory>().As<IGameEventRepository>().InstancePerRequest();
            builder.RegisterType<LeagueService>().InstancePerRequest();
            builder.RegisterType<GameEventService>().InstancePerRequest();


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            return builder.Build();
        }

    }
}