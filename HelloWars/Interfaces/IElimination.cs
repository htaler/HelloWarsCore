using System.Collections.Generic;

namespace HelloWars.Common.Interfaces
{
    public interface IElimination
    {
        List<ICompetitor> Bots { get; }
        IList<ICompetitor> GetNextCompetitors();
        void SetLastDuelResult(IDictionary<ICompetitor, int> result);
        string GetGameDescription();
    }
}
