using System.Threading.Tasks;
using HelloWars.Common.Interfaces;

namespace HelloWars.ArenaServer.Interfaces
{
    public interface ICompetitorService
    {
        void Verify(string gameType, ICompetitor competitor);
    }
}
