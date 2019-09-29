using System.Collections.Generic;
using GracenoteSportsApi.Core.GracenoteSports.GameEvents;
using GracenoteSportsApi.Core.Interfaces;

namespace GracenoteSportsApi.Infrastructure.Data
{
    public class InMemoryGameEventReposigory : IGameEventRepository
    {
        private static readonly List<GameEvent> GameEvents = new List<GameEvent>();
        public GameEvent Create(GameEvent gameEvent)
        {
            GameEvents.Add(gameEvent);
            return gameEvent;
        }

        public IEnumerable<GameEvent> GetAll()
        {
            return GameEvents;
        }
    }
}