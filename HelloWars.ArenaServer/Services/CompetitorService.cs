using System;
using System.Threading.Tasks;
using HelloWars.ArenaServer.Helpers;
using HelloWars.ArenaServer.Interfaces;
using HelloWars.ArenaServer.Models;
using HelloWars.Common.Interfaces;

namespace HelloWars.ArenaServer.Services
{
    public class CompetitorService : ICompetitorService
    {
        public void Verify(string gameType, ICompetitor competitor)
        {
            competitor.IsVerified = false;
            var competitorInfo = LoadCompetitor(competitor.Url);

            if (competitorInfo.GameType != gameType)
            {
                throw new ArgumentException("Game type mismatch");
            }
            //
            competitor.IsVerified = true;
        }

        private CompetitorInfo LoadCompetitor(string url)
        {
            //TODO: add info to app config
            return WebClientHelper.GetData<CompetitorInfo>(url + "info");
        }
    }
}
