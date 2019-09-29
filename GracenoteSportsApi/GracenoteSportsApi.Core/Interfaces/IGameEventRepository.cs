using System.Collections.Generic;
using GracenoteSportsApi.Core.GracenoteSports.GameEvents;

namespace GracenoteSportsApi.Core.Interfaces
{
    public interface IGameEventRepository
    {
        GameEvent Create(GameEvent gameEvent);
        IEnumerable<GameEvent> GetAll();
    }
}