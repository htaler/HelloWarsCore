using System.Threading.Tasks;
using Common.Models;
using HelloWars.ArenaServer.Helpers;
using HelloWars.Common.Interfaces;

namespace HelloWars.Common.Models
{
    public class BotClientBase<TArenaInfo, TMove> : Competitor, IBotClient<TArenaInfo, TMove>
    {

        private const string PerformNextMoveUrlSuffixName = "PerformNextMove";

        public BotClientBase()
        { }

        public BotClientBase(ICompetitor competitor) : base(competitor)
        { }

        public virtual async Task<TMove> NextMoveAsync(TArenaInfo arenaInfo)
        {
            //TODO: PerformNextMove add to config file
            return await WebClientHelper.PostDataAsync<TArenaInfo, TMove>(Url + PerformNextMoveUrlSuffixName, arenaInfo);
        }
    }
}