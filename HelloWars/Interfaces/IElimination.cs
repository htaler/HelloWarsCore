using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IElimination
    {
        List<ICompetitor> Bots { get; set; }
        IList<ICompetitor> GetNextCompetitors();
        void SetLastDuelResult(IDictionary<ICompetitor, double> result);
        string GetGameDescription();
    }
}
