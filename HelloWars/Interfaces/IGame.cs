using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWars.Common.Models;

namespace HelloWars.Common.Interfaces
{
    public interface IGame
    {
        Task<RoundResult> PerformNextRoundAsync();
        void SetupNewGame(IEnumerable<ICompetitor> competitors);
        void Reset();
        void SetPreview(object boardState);
        string GetGameRules();
        void ApplyConfiguration(string configurationXml);
        void ChangeDelayTime(int delayTime);
    }
}
