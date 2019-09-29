using System.Collections.Generic;
using System.Linq;
using GracenoteSportsApi.Core.Interfaces;

namespace GracenoteSportsApi.Core.GracenoteSports.GameEvents
{
    public class GameEventService
    {
        private readonly IGameEventRepository _gameEventRepository;

        public GameEventService(IGameEventRepository gameEventRepository)
        {
            _gameEventRepository = gameEventRepository;
        }
        public GameEvent Create(GameEvent gameEvent)
        {
            var events = _gameEventRepository.GetAll();
            var id = events.Count();
            gameEvent.Id = id + 1;
            _gameEventRepository.Create(gameEvent);
            return gameEvent;
        }

        public IEnumerable<GameEvent> GetAll()
        {
            return _gameEventRepository.GetAll();
        }
    }
}