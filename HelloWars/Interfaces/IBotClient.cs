using System.Threading.Tasks;

namespace HelloWars.Common.Interfaces
{
    public interface IBotClient<TArenaInfo, TMove> : ICompetitor
    {
        Task<TMove> NextMoveAsync(TArenaInfo arenaInfo);
    }
}
