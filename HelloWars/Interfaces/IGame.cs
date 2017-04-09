using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces
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
